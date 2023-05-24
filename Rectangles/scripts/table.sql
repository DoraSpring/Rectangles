create table point
(
    id int not null identity(1,1) primary key,
    x  int not null,
    y  int not null,
    constraint un_rectangle_point unique(x,y)
);

create table rectangle
(
    id int not null identity(1,1) primary key,
	point1 int not null,
	point2 int not null,
    constraint un_rectangle unique(point1,point2),
	foreign key (point1) references point(id),
	foreign key (point2) references point(id),
);
