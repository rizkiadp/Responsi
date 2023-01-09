CREATE DATABASE retailer_DB
USE retailer_DB

CREATE TABLE products(
	uid INT NOT NULL IDENTITY(1,1),
	name VARCHAR(50) NOT NULL,
	status TINYINT NOT NULL DEFAULT 1,
	PRIMARY KEY (uid)
)


INSERT INTO products VALUES ('XYZ Sarden Extra Pedas 35gr', '1') 
INSERT INTO products VALUES ('XYZ Makarel Extra Pedas 150gr', '1') 
INSERT INTO products VALUES ('XYZ Kecap Manis 125ml', '1') 
INSERT INTO products VALUES ('XYZ Sirup Karamel 250ml', '1') 
INSERT INTO products VALUES ('XYZ Batrai AA (Pack isi 4)', '1')

select * from products