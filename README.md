# school-management-system
School management system
> Note! Install [ERD Editor](https://marketplace.visualstudio.com/items?itemName=dineug.vuerd-vscode) extension to vscode to open `*.vuerd.json` file.
***
> Gateways

### Admin
### Students

***
> Service APIs

## End points

### Identity.API
```C#
Accounts
POST	accounts/register
POST	accounts/login
PUT	accounts/{username}
GET	accounts/{username}
```

### Sciences.API
```C#
Sciences - Fanlar, Kunlik o'tilgan mavzular, Mavzular bo'yicha berilgan vazifalar
GET	sciences
POST	sciences
PUT	sciences/{science_id}
GET	sciences/{science_id}
DELETE  sciences/{science_id}
GET	sciences/{science_id}/topics
POST    sciences/{science_id}/topics
PUT	sciences/{science_id}/topics/{date}
POST    sciences/{science_id}/topics/{date}/tasks
GET	sciences/{science_id}/topics/{date}/tasks
PUT	sciences/{science_id}/topics/{date}/tasks/{task_id}
DELETE  sciences/{science_id}/topics/{date}/tasks/{task_id}

```

### Students.API
```C#
Students - O'quvchilar, O'quvchilarning darsga qatnashishi
GET	students
POST	students
PUT	students/{username}
GET	students/{username}
DELETE  students/{username}
GET	students/{username}/attendances
POST	students/{username}/attendances
PUT	students/{username}/attendances

GET	students/{username}/sciences
POST	students/{username}/sciences
GET	students/{username}/sciences/{science_id}
PUT	students/{username}/sciences/{science_id}
DELETE  students/{username}/sciences/{science_id}

GET	students/{username}/task-results
POST	students/{username}/task-results
GET	students/{username}/task-results/{task_id}
PUT	students/{username}/task-results/{task_id}
DELETE  students/{username}/task-results/{task_id}

```
