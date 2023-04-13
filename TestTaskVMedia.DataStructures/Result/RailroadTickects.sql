create table Passengers
(
    Id    INTEGER not null
        constraint PK_Passengers
            primary key autoincrement,
    Name  TEXT    not null,
    Email TEXT    not null
);

create table Trains
(
    Id          INTEGER not null
        constraint PK_Trains
            primary key autoincrement,
    Name        TEXT    not null,
    Origin      TEXT    not null,
    Destination TEXT    not null
);

create table Tickets
(
    Id            INTEGER not null
        constraint PK_Tickets
            primary key autoincrement,
    PassengerId   INTEGER not null
        constraint FK_Tickets_Passengers_PassengerId
            references Passengers
            on delete cascade,
    TrainId       INTEGER not null
        constraint FK_Tickets_Trains_TrainId
            references Trains
            on delete cascade,
    DepartureTime TEXT    not null,
    ArrivalTime   TEXT    not null,
    Price         TEXT    not null
);

create index IX_Tickets_PassengerId
    on Tickets (PassengerId);

create index IX_Tickets_TrainId
    on Tickets (TrainId);