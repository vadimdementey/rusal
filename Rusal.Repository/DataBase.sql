CREATE DATABASE [rusal_tasks_db]
Go
use [rusal_tasks_db]
Go

create table UserAccounts
(
    [UserId] [uniqueidentifier] NOT NULL,
	[UserName][nvarchar](50) NULL,
	[UserLoginName][nvarchar](50) NULL,
	[UserPasswordHash][uniqueidentifier] NOT NULL,
	primary key([UserId])
)
go
create table TaskPriorities
(
   [Code] int not null,
   [Name] nvarchar(50) not null,
   primary key ([Code])
)
go
create table Tasks
(
       [TaskId] [uniqueidentifier] NOT NULL,
	   [ParentTaskId] [uniqueidentifier]  NULL,
	   [TaskName][nvarchar](100) NULL,
	   [AuthorId] [uniqueidentifier]  NOT NULL,
	   [EmployeeId] [uniqueidentifier]  NOT NULL,
	   [TaskCreatedDateTime] [datetime]  NOT NULL,
	   [TaskPriorityCode] [int]  NOT NULL,
	   [TaskCompleted] [bit]  NOT NULL,
	   [TaskDescription][nvarchar](100) NULL,
	   primary key([TaskId])

)
go 
insert into TaskPriorities(code,name) values(1,N'Низкий');
insert into TaskPriorities(code,name) values(2,N'Средний');
insert into TaskPriorities(code,name) values(3,N'Высокий');
go
insert into [UserAccounts](UserId,UserName, UserLoginName,UserPasswordHash) 
  values('8C4F7B49-00C9-4616-9BBF-560F464EA783','Power User','Power User','8D721EC8-4C9D-632F-6F06-7F89CC14862C')

insert into [UserAccounts](UserId,UserName, UserLoginName,UserPasswordHash) 
  values('45B63E3B-E6F8-4394-B940-8DC9B17378CC','Admin','Admin','3842CAC4-B9A0-8223-0DCC-509A6F75849B')

insert into [UserAccounts](UserId,UserName, UserLoginName,UserPasswordHash) 
  values('8839BCDF-E955-43A9-9F45-D9EAC9694392','User','User','7EC8CBEC-5C4B-FEE2-2830-8FD9F2A7BAF3')

