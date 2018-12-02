/*drop sequence books_seq cascade;
drop sequence persons_seq cascade;
drop sequence users_seq cascade;
drop database rest_with_asp_net_udemy;
**/
create database rest_with_asp_net_udemy;
create user postgres with encrypted password 'root';
grant all privileges on database rest_with_asp_net_udemy to postgres;



create database rest_with_asp_net_udemy;


create sequence books_seq;

create table if not exists books (
  id int not null default nextval ('books_seq'),
  author varchar(150),
  launchdate timestamp(6) not null,
  price decimal(65,2) not null,
  title varchar(250),
  primary key (id)
)  ;

create sequence persons_seq;

create table if not exists persons (
  id int not null default nextval ('persons_seq'),
  firstname varchar(50) default null,
  lastname varchar(50) default null,
  address varchar(50) default null,
  gender varchar(50) default null,
  primary key (id)
)  ;

create sequence users_seq;

create table if not exists users (
  id int not null default nextval ('users_seq'),
  login varchar(50) not null,
  accesskey varchar(50) not null,
  primary key (id),
  constraint login unique  (login)
)  ;