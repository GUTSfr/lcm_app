# LCM Web API (C# / ASP.NET Core 8)

## Что делает
GET endpoint возвращает НОК (LCM) двух неотрицательных целых чисел.
- Если оба числа корректны → возвращает строку с числом (plain text)
- Если хотя бы одно некорректно → возвращает `NaN`

## Перед деплоем
В `Program.cs` замени `your_email_here` на slug своего email.
Например, для `john.doe@gmail.com` → `john_doe_gmail_com`

## Локальный запуск
```bash
dotnet run
# Сервер поднимется на http://localhost:5000
```

## Тест
```
GET http://localhost:5000/your_email_slug?x=4&y=6  → 12
GET http://localhost:5000/your_email_slug?x=0&y=5  → 0
GET http://localhost:5000/your_email_slug?x=-1&y=5 → NaN
GET http://localhost:5000/your_email_slug?x=abc&y=5 → NaN
```

## Деплой на Render.com (бесплатно, поддерживает Docker)
1. Создай аккаунт на https://render.com
2. New → Web Service → Connect GitHub repo (залей туда эту папку)
3. Runtime: Docker
4. Port: 5000
5. После деплоя URL будет вида: https://lcm-app.onrender.com/your_email_slug

## Деплой на Railway.app (альтернатива)
1. https://railway.app → New Project → Deploy from GitHub
2. Автоматически найдёт Dockerfile
3. В настройках поставь PORT=5000

## URL для сабмита
```
!task3 your@email.com https://your-app.onrender.com/your_email_slug?x={}&y={}
```
