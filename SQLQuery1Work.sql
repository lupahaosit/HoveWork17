CREATE TABLE [dbo].[InfoTable] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Surname]  NVARCHAR (20) NOT NULL,
    WorkerNAME     NVARCHAR (20) NOT NULL,
    [LASTNAME] NVARCHAR (20) NOT NULL,
    [NUMBER]   INT           NULL,
    [EMAIL]    NVARCHAR (20) NOT NULL
);



Insert Into InfoTable (Surname,WorkerNAME, LASTNAME, NUMBER, EMAIL)
values ('WorkerSurname1','WorkerName1','WorkerLastName1','','Worker1@mail.ru')
Insert Into InfoTable (Surname, WorkerNAME, LASTNAME, NUMBER, EMAIL)
values ('WorkerSurname2','WorkerName2','WorkerLastName2','','Worker2@mail.ru')
Insert Into InfoTable (Surname, WorkerNAME, LASTNAME, NUMBER, EMAIL)
values ('WorkerSurname3','WorkerName3','WorkerLastName3','','Worker3@mail.ru')
Insert Into InfoTable (Surname, WorkerNAME, LASTNAME, NUMBER, EMAIL)
values ('WorkerSurname4','WorkerName4','WorkerLastName4','','Worker4@mail.ru')
Insert Into InfoTable (Surname, WorkerNAME, LASTNAME, NUMBER, EMAIL)
values ('WorkerSurname5','WorkerName5','WorkerLastName5','','Worker5@mail.ru')
Insert Into InfoTable (Surname, WorkerNAME, LASTNAME, NUMBER, EMAIL)
values ('WorkerSurname6','WorkerName6','WorkerLastName6','','Worker6@mail.ru')
Insert Into InfoTable (Surname, WorkerNAME, LASTNAME, NUMBER, EMAIL)
values ('WorkerSurname7','WorkerName7','WorkerLastName7','','Worker7@mail.ru')
Insert Into InfoTable (Surname, WorkerNAME, LASTNAME, NUMBER, EMAIL)
values ('WorkerSurname8','WorkerName8','WorkerLastName8','','Worker8@mail.ru')
Insert Into InfoTable (Surname, WorkerNAME, LASTNAME, NUMBER, EMAIL)
values ('WorkerSurname9','WorkerName9','WorkerLastName9','','Worker9@mail.ru')
Insert Into InfoTable (Surname, WorkerNAME, LASTNAME, NUMBER, EMAIL)
values ('WorkerSurname10','WorkerName10','WorkerLastName10','','Worker10@mail.ru')

Delete from InfoTable where InfoTable.Id>1
Select * from InfoTable
drop table InfoTable
