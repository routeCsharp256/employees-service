# EmployeesService

Сервис контроля сотрудников, который создается в рамках обучающей программы кафедры C# проекта Route256

###Инфраструктура:
- БД postgres (docker-compose)
- kafka (docker-compose)
- zookeper (docker-compose)

###Возмоности сервиса:
- Создание нового сотрудника
  - Вызывается REST API сервиса "Сервис сотрудников"
  - В БД "Сервиса сотрудников" создается запись, что новый сотрудник принят на работу
  - В Kafka отправляется сообщение, что сотруднику нужно выдать мерч
- Отправка сотрудника на конференцию
  - Вызывается REST API сервиса "Сервис сотрудников"
  - В БД "Сервиса сотрудников" создается запись, что сотрудник идет на конференцию
  - В Kafka отправляется сообщение, что сотрудник идет на конференцию
- Получения списка всех сотрудников
- Получение списка всех конференций

###Схема БД:
Схема состоит из 3х таблиц _employees_ _conferences_ и таблица связи _employeesconferences_

| employees | | | | | | |
|----|------------|-----------|-------------|-------|-----------|-------------|
| id | first_name | last_name | middle_name | email | birth_day | hiring_date |
| PK bigserial | str(100) NotN | str(100) NotN | str(100) NotN | str(100) NotN | timestamptz | timestamptz |

| conferences | | | | |
|----|------------|-----------|-------------|-------|
| id | name | create_date | date | description |
| PK bigserial | str(500) NotN | timestamptz | timestamptz | text |

| employeesconferences | |
|----|------------|
| employees_id | conferences_id |
| long | long |

