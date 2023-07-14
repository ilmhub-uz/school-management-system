# school-management-system
School management system

***
# Setup
- Install [ERD Editor](https://marketplace.visualstudio.com/items?itemName=dineug.vuerd-vscode) extension to vscode to open `*.vuerd.json` file.
- Install [Draw.io](https://marketplace.visualstudio.com/items?itemName=hediet.vscode-drawio) extension to vscode to open `*.drawio` file.
***

### Branch Rules
- always rebase from `master` branch
- your new feature branch name should follow the rule `your_name/changes-summary`. *ex: `ali/identity-setup`*
- always create a PR to `master` branch

### PR Rules
- PR title should follow the rule: `changes small summary`. *ex: `Setup new repo`*
- Write a small description explaining what this PR does. *ex: Created a new repo for microservices solution*

***

## Gateways

- Admin
- Students

***

## Service APIs

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
Students - O'quvchilar, O'quvchilarning darsga qatnashishi, fanlari va mavzu bo'yicha berilgan topshiriqlar natijalari
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

### Chats.API
```C#
Chats - Foydalanuvchilar mavzuga yoki vazifaga izoh qoldirishi uchun. Foydalanuvchilar bir biri bilan va fan bo'yicha ochilgan guruhda suhbatlashishi mumkin

GET	chats
POST	chats
GET	chats/{chat_id}
PUT	chats/{chat_id}
DELETE  chats/{chat_id}

GET	chats/{chat_id}/messages
POST	chats/{chat_id}/messages
PUT	chats/{chat_id}/messages/{message_id}
DELETE  chats/{chat_id}/messages/{message_id}

```

***
### Tables
![Diagram](/school-management-db-diagram.png?raw=true)

***

# Points

> ### Contribute to get points

| No | User | Point |
| :---         |     :---:      |    :---:      |
| 1 | JamolMeyliyev | 2 |
| 2 | azizaskarow | 1 |
| 3 | Sardorbekakhmedov | 3 |
***
