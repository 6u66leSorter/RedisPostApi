# RedisPost API

Простой API для управления постами с использованием Redis в качестве хранилища данных.

## 🛠 Установка и запуск

### Требования

- **Docker** для работы с Redis.
- **.NET 8.0 SDK** для сборки и запуска проекта.
- **Docker Compose** для удобного запуска всех сервисов.

### 1. Клонирование репозитория

Клонируйте репозиторий на локальную машину:

```bash
git clone https://github.com/6u66leSorter/RedisPostApi.git
cd RedisPostApi
```

### 2. Сборка и запуск приложения

```bash
docker-compose up -d --build
```

### 3. Проверка функционала

После запуска приложения перейдите по адресу http://localhost:5000/swagger/index.html 

**Создание поста**
POST /posts
Тело запроса:
{
  "id": "1",
  "title": "Post Title",
  "content": "Post Content"
}

**Получение поста по ID**
GET /posts/{id}
Пример: GET /posts/1
Тестовые данные:
{
  "id": "1",
  "title": "Post Title",
  "content": "Post Content"
}

**Обновление поста**
PUT /posts/{id}
Тело запроса:
{
  "id": "1",
  "title": "Updated Title",
  "content": "Updated Content"
}

Удаление поста
DELETE /posts/{id}
Тело запроса:
{
  "id": "1"
}

**Проверка Middleware**
В разделе Response Headers заголовок:
Header1: 123


