#Bank System Fundamentals (BSF)

###Dev3o
1. Aleksandar Aćimović
2. Berina Cocalić
3. Emir Bećirović

##Opis teme

Bank System Fundamentals (BSF) je sistem koji se, kao sto i ime kaze, bavi osnovnim bankarskim procesima. On automatizuje najucestalije bankarske radnje.
Ovaj sistem je namjenjen administraciji i uposlenicima bankarskih, i/ili slicnih, institucija, kao i njihovim klijentima.
Sistem omogucjuje korisnicima brzi i jednostavniji pregled informacija racuna, transakcije, konverzije valuta i sl.

##Procesi

###Kreiranje racuna //DORADITI!

Nakon sto kranji korisnik popuni formu sa svim potrebnim podatcima o svom racunu salje zahtjev koji je na cekanju.
Taj zahtjev ceka odobrenje uposlenika unutar institucije. Uposlenik prima obavjest o novom zahtjevu i nakon pregledavanja ga odobrava.

###Transakcija

Transakcija se moze obaviti na vise nacina:

1. Sa racuna na racun:
	Korisnik unosi broj racuna na koji uplacuje, prenosti, sredstva sa svog. Unosi kolicinu i sifru svog racuna. Nakon unesenih podataka on salje zahtjev,
	zahtjev se procesuira tako sto korisnik dobije kod verifikacije na mobitel. Taj kod dalje unosi u formu koja potvrdjuje transakciju.
	Ukoliko je doslo do greske korisnik ima pravo u narednih 24 sata da ponisti transakciju.
2. Preko filijale, gotovinski:
	Krajnji korisnik uposleniku u filijali predaje gotovinu i podatke racuna na koji se sretstva uplacuju.
	Nakon sto uposlenik unese u formu sve potrebne podatke i izvrsi zahtjev, u slucaju greske unutar 24 sata transakcija moze biti ponistena.
	
###Ponistavanje transakcija

Ponistavanje transakcija se moze obaviti na vise nacina:

1. Preko korisnickog racuna:
	Korisnik ima pregled svih obavljenih transakcija. Unutar 24 sata nakon transakcije pored nje stoji opcija za ponistavanjem.
	Korisnik moze da ponisti transakciju birajuci tu opciju i popunjavajuci podatke za verifikaciju. Verifikacija se vrsi u dva koraka, korisnickom sifrom i unosenjem koda dobijenog preko SMS poruke.
2. Preko filijale:
	Korisnik uposleniku predaje zahtjev za ponistenje transakcije usmenim putem i predavanjem licnih ispava sa uplatnicom transakcije unutar 24 sata nakon nje.
	Uposlenik vrsi ponistavanje.

U oba slucaja kreira se izvjestaj o ponistavanju transakcije sa svim detaljima.

###Konverzija valuta

Konverzija valuta se vrsi pri dizanju sretstava sa racuna ili direktno u filijalama. Ukoliko se sretstva dizu sa racuna onda korsnik ce imati opciju dizanja u devizama.
Nakon odabira opcije korisnik bira koju valutu zeli. Ukoliko se konverzija vrsi u filijali, onda konvertor predstavlja obicni kalkulator. U oba slucaja se spasava izvjestaj.

##Funkcionalnosti

	- Kreiranje profila
	- Kreiranje racuna
	- Vrsenje transakcija online i fizicki
	- Pregled izvjestajima
	- Upravljanje transakcijama
	- Konverzija valuta
	
##Akteri

	- Korisnici:
		1. Clan - predstavlja korisnika sa kreiranim profilom i racunom u banci
		2. Ostali korisnici - predstavljaju korisnike koji nisu clanovi sa profilom ili racunom u banci
	- Uposlenici:
		1. Referent - fizicki ucestvuje u procesima koji se obavljaju najcesce sa ostalim clanovima
		2. Supervizori - ucestvuju u registrovanju novih clanova 
	- Moderator - predstavlja osobu na visim nivoima kojem je i zaduzenje dodjeljivanje privilegija uposlenicima

	
   