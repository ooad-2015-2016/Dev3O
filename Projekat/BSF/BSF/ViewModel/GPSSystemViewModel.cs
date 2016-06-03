using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.UI;
using Windows.UI.Xaml.Controls.Maps;

namespace BSF.ViewModel
{
    class GPSSystemViewModel
    {
        
        private Geopoint currentLocation;
        public Geopoint CurrentLocation { get { return currentLocation; } set { currentLocation = value; OnNotifyPropertyChanged("TrenutnaLokacija"); } }
        
        private string location;
        public string Location { get { return location; } set { location = value; OnNotifyPropertyChanged("Lokacija"); } }
        private string adress;
        public string Adress { get { return adress; } set { adress = value; OnNotifyPropertyChanged("Adresa"); } }
        
        MapControl Mapa;

        public GPSSystemViewModel(MapControl mapa)
        {
            Mapa = mapa;
            getLocation();
        }

        public async void getLocation()
        {
            Geoposition pos = null;
           
            var accessStatus = await Geolocator.RequestAccessAsync();
            if (accessStatus == GeolocationAccessStatus.Allowed)
            {
                
                Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = 10 };
                pos = await geolocator.GetGeopositionAsync();
            }
            
            CurrentLocation = pos.Coordinate.Point;
            Location = "Geolokacija Lat: " + CurrentLocation.Position.Latitude + " Lng: " + CurrentLocation.Position.Longitude;
           
            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(pos.Coordinate.Point);
            
            if (result.Status == MapLocationFinderStatus.Success)
            {
                Adress = "Adresa je " + result.Locations[0].Address.Street;
            }
            
            double centerLatitude = Mapa.Center.Position.Latitude;
            double centerLongitude = Mapa.Center.Position.Longitude;
            MapPolyline mapPolyline = new MapPolyline();
            mapPolyline.Path = new Geopath(new List<BasicGeoposition>() {
                     new BasicGeoposition() {Latitude=centerLatitude-0.0005, Longitude=centerLongitude-0.001 },
                     new BasicGeoposition() {Latitude=centerLatitude+0.0005, Longitude=centerLongitude-0.001 },
                     new BasicGeoposition() {Latitude=centerLatitude+0.0005, Longitude=centerLongitude+0.001 },
                     new BasicGeoposition() {Latitude=centerLatitude-0.0005, Longitude=centerLongitude+0.001 },
                     new BasicGeoposition() {Latitude=centerLatitude-0.0005, Longitude=centerLongitude-0.001 }
               });
            mapPolyline.StrokeColor = Colors.Black;
            mapPolyline.StrokeThickness = 3;
            mapPolyline.StrokeDashed = true;
            Mapa.MapElements.Add(mapPolyline);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
