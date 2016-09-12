
if not (exists(select * from [dbo].[Position]))
begin
set IDENTITY_INSERT [dbo].[Position] on 

insert [dbo].[Position] ([ID], [Title]) values (1000, N'Программист')
insert [dbo].[Position] ([ID], [Title]) values (1001, N'Дизайнер')

set IDENTITY_INSERT [dbo].[Position] off
end 

if not (exists(select * from [dbo].[Skill]))
begin
set IDENTITY_INSERT [dbo].[Skill] on 

insert [dbo].[Skill] ([ID], [PositionId], [Title]) values (1000, 1000, N'C++')
insert [dbo].[Skill] ([ID], [PositionId], [Title]) values (1001, 1000, N'C#')
insert [dbo].[Skill] ([ID], [PositionId], [Title]) values (1002, 1000, N'Java')

insert [dbo].[Skill] ([ID], [PositionId], [Title]) values (1003, 1001, N'xaml')
insert [dbo].[Skill] ([ID], [PositionId], [Title]) values (1004, 1001, N'css')

set IDENTITY_INSERT [dbo].[Skill] off
end

if not (exists(select * from [dbo].[Employee]))
begin
set IDENTITY_INSERT [dbo].[Employee] on 

insert [dbo].[Employee] ([ID], [PositionId], [Name]) values (1000, 1000, N'Рядовой программист')
insert [dbo].[Employee] ([ID], [PositionId], [Name]) values (1001, 1001, N'Рядовой дизайнер')

set IDENTITY_INSERT [dbo].[Employee] off
end
