# school-management-system
School management system

***
## End points
```C#
Accounts
POST	accounts/register
POST	accounts/login
PUT	accounts/{username}
GET	accounts/{username}

Students - O'quvchilar, O'quvchilarning darsga qatnashishi
GET	students
POST	students
PUT	students/{username}
GET	students/{username}
DELETE  students/{username}
GET	students/{username}/attendance
POST	students/{username}/attendance
PUT	students/{username}/attendance

Sciences - Fanlar, Kunlik o'tilgan mavzular, Mavzular bo'yicha berilgan vazifalar
GET	sciences
POST	sciences
PUT	sciences/{scienceId}
GET	sciences/{scienceId}
DELETE  sciences/{scienceId}
GET	sciences/{scienceId}/topics
POST    sciences/{scienceId}/topics
PUT	sciences/{scienceId}/topics/{date}
POST    sciences/{scienceId}/topics/{date}/tasks
GET	sciences/{scienceId}/topics/{date}/tasks
PUT	sciences/{scienceId}/topics/{date}/tasks/{taskId}
DELETE  sciences/{scienceId}/topics/{date}/tasks/{taskId}

```
