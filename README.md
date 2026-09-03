# בניית טפסים וניהול אבני דרך

אב-טיפוס למחלקת הון אנושי ברשות המיסים: יצירת תבנית טופס עם שדות דינמיים ומסלול אישורים.

## סטאק

- צד לקוח: Angular 20 (standalone, signals, Reactive Forms, zoneless)
- צד שרת: ASP.NET Core 8 Web API
- שמירת נתונים: מאגר בזיכרון (בלי מסד נתונים בשלב זה)

## הרצה

שני תהליכים:

```bash
cd backend/HrForms.Api
dotnet run --urls http://localhost:43142
```

```bash
cd frontend
npm start
```

הממשק: http://localhost:43143  
Swagger: http://localhost:43142/swagger

הנתונים נמחקים כשעוצרים את השרת.

## API

| פעולה | נתיב |
|--------|------|
| רשימת טפסים | `GET /api/form-templates` |
| טופס לפי מזהה | `GET /api/form-templates/{id}` |
| שמירת טופס בשלמותו | `POST /api/form-templates` |

## שימוש ב-AI

הפיתוח בוצע בסיוע Cursor.
