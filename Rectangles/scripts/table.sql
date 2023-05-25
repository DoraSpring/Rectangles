create table coordinate
(
    id int not null identity(1,1) primary key,
    x  int not null,
    y  int not null,
    constraint un_coordinate unique(x,y)
);

create table rectangle
(
    id            int not null identity(1,1) primary key,
	coordinate_id int not null,
    width         int not null,
    height        int not null,
    constraint un_rectangle unique(coordinate_id,width,height),
	foreign key (coordinate_id) references coordinate(id)
);
