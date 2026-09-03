# בניית טפסים וניהול אבני דרך

אב-טיפוס למחלקת הון אנושי ברשות המיסים: יצירת תבנית טופס עם שדות דינמיים ומסלול אישורים.

## סטאק

- צד שרת: ASP.NET Core 8 Web API
- שמירת נתונים: מאגר בזיכרון (בלי מסד נתונים בשלב זה)
- צד לקוח: Angular — יתווסף אחרי שה-API יציב

## הרצה מקומית

דרישות: .NET 8 SDK.

```bash
cd backend/HrForms.Api
dotnet run --urls http://localhost:43142
```

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
