# interaction-bdd-crud2
techno: C# 
Ide: visual studio
connection à la base de donnée myql "disquaire"
réalisation du CRUD
affichage en console de requête
sql de la base de donnée:
SET NAMES utf8;
drop database if exists disquaire;
create database disquaire;
use disquaire;
​
CREATE TABLE contact (
    id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    mail VARCHAR(50) NOT NULL,
    first_name VARCHAR(40) NOT NULL,
	last_name VARCHAR(40) NOT NULL,
	password VARCHAR(40) NOT NULL,
    PRIMARY KEY (id)
)
ENGINE=INNODB;
​
CREATE TABLE album (
    id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    title VARCHAR(50) NOT NULL,
	created_year YEAR NOT NULL,
    PRIMARY KEY (id)
)
ENGINE=INNODB;
​
CREATE TABLE artist (
    id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    name VARCHAR(50) NOT NULL,
	birthday DATE NOT NULL,
    PRIMARY KEY (id)
)
ENGINE=INNODB;
​
CREATE TABLE booking (
    id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
	booked_at DATETIME NOT NULL,
    id_contact SMALLINT UNSIGNED NOT NULL,
    id_album SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (id),
    
    -- relation un à un ! grâce à l'index unique
    UNIQUE KEY uni_id_album (id_album),
    CONSTRAINT fk_booking_album         
		FOREIGN KEY (id_album)            
		REFERENCES album(id),
	
    -- relation plusieurs à un
	CONSTRAINT fk_reser_contact       
		FOREIGN KEY (id_contact)            
		REFERENCES contact(id)  
)
ENGINE=INNODB;
​
​
-- relation plusieurs à plusieurs avec les deux clefs étrangères et le unique key (id_album, id_artist)
CREATE TABLE album_artist (
    id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    id_album SMALLINT UNSIGNED NOT NULL,
    id_artist SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (id),
    UNIQUE KEY uni_id_album_id_artist (id_album, id_artist),
    CONSTRAINT fk_album_artist_album         
		FOREIGN KEY (id_album)            
		REFERENCES album(id),        
	CONSTRAINT fk_album_artist_artist       
		FOREIGN KEY (id_artist)            
		REFERENCES artist(id) 
)
ENGINE=INNODB;
​
​
insert into artist values(1, 'Geroges Brassens', '1921-10-22');
insert into artist values(2, 'Vianney', '1991-02-13');
insert into artist values(3, 'Patrick Fiori', '1969-09-23');
​
insert into album values(1, 'Le Vent', '1954');
insert into album values(2, 'Fernande', '1972');
insert into album values(3, 'Je me suis fait tout petit', '1956');
insert into album values(4, 'Idées blanches', '2014');
insert into album values(5, 'Le Monde des Enfoirés', '2019');
insert into album values(6, 'Choisir', '2014');
​
-- associer les albums aux artistes et vice versa relation plusieurs à plusieurs
insert into album_artist values(1, 1, 1);
insert into album_artist values(2, 2, 1);
insert into album_artist values(3, 3, 1);
insert into album_artist values(4, 4, 2);
insert into album_artist values(5, 5, 2);
insert into album_artist values(6, 5, 3);
insert into album_artist values(7, 6, 3);
​
insert into contact values(1, 'jean.dupont@gmail.com', 'Jean', 'Dupont', 'ddddd');
insert into contact values(2, 'david.martin@gmail.com', 'David', 'Martin', 'mmmmm');
insert into contact values(3, 'lionel.chamoulaud@gmail.com', 'Lionel', 'Chamoulaud', 'ccccc');
​
​
insert into booking values(1, '2020-01-01 12:00:00', 1, 2);
insert into booking values(2, '2020-10-10 13:00:00', 2, 3);
insert into booking values(3, '2020-09-10 15:00:00', 2, 4);
insert into booking values(4, '2020-12-25 08:00:00', 3, 5);
