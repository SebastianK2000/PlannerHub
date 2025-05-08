CREATE TABLE Users (
    IDuser INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Phone NVARCHAR(15) NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Address NVARCHAR(100) NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);

CREATE TABLE Accommodations (
    IDaccommodation INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Type NVARCHAR(50) NOT NULL,
    Address NVARCHAR(200),
    Price DECIMAL(10, 2) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);


CREATE TABLE Bookings (
    IDbooking INT IDENTITY(1,1) PRIMARY KEY,
    IDuser INT NOT NULL,
    IDaccommodation INT NOT NULL,
    BookingDate DATETIME DEFAULT GETDATE(),
    CheckInDate DATETIME,
    CheckOutDate DATETIME,
    TotalPrice DECIMAL(10, 2),
    Status NVARCHAR(50) DEFAULT 'Pending', 
    FOREIGN KEY (IDuser) REFERENCES Users(IDuser),
    FOREIGN KEY (IDaccommodation) REFERENCES Accommodations(IDaccommodation)
);


CREATE TABLE Trips (
    IDtrip INT IDENTITY(1,1) PRIMARY KEY,
    IDuser INT NOT NULL,
    TripName NVARCHAR(100) NOT NULL,
    StartDate DATETIME,
    EndDate DATETIME,
    Destination NVARCHAR(100),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (IDuser) REFERENCES Users(IDuser)
);


CREATE TABLE Payments (
    IDpayment INT IDENTITY(1,1) PRIMARY KEY,
    IDbooking INT NOT NULL,
    PaymentDate DATETIME DEFAULT GETDATE(),
    Amount DECIMAL(10, 2),
    PaymentMethod NVARCHAR(50),
    Status NVARCHAR(50) DEFAULT 'Pending',
    FOREIGN KEY (IDbooking) REFERENCES Bookings(IDbooking)
);


CREATE TABLE Teams (
    IDteam INT IDENTITY(1,1) PRIMARY KEY,
    TeamName NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE TeamMembers (
    IDteam INT NOT NULL,
    IDuser INT NOT NULL,
    JoinDate DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (IDteam, IDuser),
    FOREIGN KEY (IDteam) REFERENCES Teams(IDteam),
    FOREIGN KEY (IDuser) REFERENCES Users(IDuser)
);

CREATE TABLE TripUsers (
    IDtrip INT NOT NULL,
    IDuser INT NOT NULL,
    JoinDate DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (IDtrip, IDuser),
    FOREIGN KEY (IDtrip) REFERENCES Trips(IDtrip),
    FOREIGN KEY (IDuser) REFERENCES Users(IDuser)
);

CREATE TABLE BookingDetails (
    IDbooking INT NOT NULL,
    IDaccommodation INT NOT NULL,
    ServiceName NVARCHAR(100),
    Price DECIMAL(10, 2),
    PRIMARY KEY (IDbooking, IDaccommodation),
    FOREIGN KEY (IDbooking) REFERENCES Bookings(IDbooking),
    FOREIGN KEY (IDaccommodation) REFERENCES Accommodations(IDaccommodation)
);
