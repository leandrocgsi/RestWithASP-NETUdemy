/*DROP SEQUENCE books_seq CASCADE;
DROP SEQUENCE persons_seq CASCADE;
DROP SEQUENCE users_seq CASCADE;
DROP database rest_with_asp_net_udemy;
**/
CREATE DATABASE rest_with_asp_net_udemy;
CREATE USER postgres WITH ENCRYPTED PASSWORD 'root';
GRANT ALL PRIVILEGES ON DATABASE rest_with_asp_net_udemy TO postgres;



CREATE DATABASE rest_with_asp_net_udemy;


CREATE SEQUENCE books_seq;

CREATE TABLE IF NOT EXISTS books (
  id int NOT NULL DEFAULT NEXTVAL ('books_seq'),
  Author varchar(150),
  LaunchDate timestamp(6) NOT NULL,
  Price decimal(65,2) NOT NULL,
  Title varchar(250),
  PRIMARY KEY (id)
)  ;

CREATE SEQUENCE persons_seq;

CREATE TABLE IF NOT EXISTS persons (
  Id int NOT NULL DEFAULT NEXTVAL ('persons_seq'),
  FirstName varchar(50) DEFAULT NULL,
  LastName varchar(50) DEFAULT NULL,
  Address varchar(50) DEFAULT NULL,
  Gender varchar(50) DEFAULT NULL,
  PRIMARY KEY (Id)
)  ;

CREATE SEQUENCE users_seq;

CREATE TABLE IF NOT EXISTS users (
  ID int NOT NULL DEFAULT NEXTVAL ('users_seq'),
  Login varchar(50) NOT NULL,
  AccessKey varchar(50) NOT NULL,
  PRIMARY KEY (ID),
  CONSTRAINT Login UNIQUE  (Login)
)  ;