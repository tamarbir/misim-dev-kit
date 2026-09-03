# Misim Dev Kit — מטלת בניית טפסים

ערכת פיתוח מלאה לבניית טפסים דינמיים: **Angular 20** בצד הלקוח ו-**.NET 8** בצד השרת.

המערכת מאפשרת ליצור תבניות טפסים, להגדיר שדות וולידציות, לפרסם טופס, למלא אותו ולצפות בהגשות.

## יכולות

- בונה טפסים עם סוגי שדות: טקסט, טקסט ארוך, מספר, תאריך, דוא״ל, רשימה נפתחת, רדיו ותיבת סימון
- גרירת שדות לשינוי סדר, מאפיינים לכל שדה, ושמירה כטיוטה או כטופס מפורסם
- מילוי טופס עם ולידציה בצד הלקוח ובצד השרת
- צפייה בהגשות
- ממשק עברי (RTL)
- טופס דמו מובנה: **דיווח הכנסה שנתית**
- SQLite — בלי צורך ב-SQL Server

## מבנה

```
backend/src/Misim.Forms.Api   API ב-.NET 8
backend/tests                 בדיקות אינטגרציה
frontend                    אפליקציית Angular 20
```

## דרישות

- Node.js 20+
- .NET SDK 8
- דפדפן מודרני

## הרצה מקומית

טרמינל 1 — השרת:

```bash
cd backend/src/Misim.Forms.Api
dotnet run --launch-profile http
```

ה-API זמין ב-http://localhost:5148 (Swagger ב-`/swagger`).

טרמינל 2 — הלקוח:

```bash
cd frontend
npm install
npm start
```

האפליקציה זמינה ב-http://localhost:4200 ומעבירה קריאות `/api` לשרת דרך proxy.

## בדיקות

```bash
cd backend
dotnet test
```

```bash
cd frontend
npx ng test --no-watch --browsers=ChromeHeadless
npx ng build
```

## API עיקרי

| פעולה | נתיב |
| --- | --- |
| רשימת טפסים | `GET /api/forms` |
| יצירת טופס | `POST /api/forms` |
| עדכון טופס | `PUT /api/forms/{id}` |
| פרסום | `POST /api/forms/{id}/publish` |
| הגשה | `POST /api/forms/{id}/submissions` |
| רשימת הגשות | `GET /api/forms/{id}/submissions` |

גוף יצירה/עדכון לדוגמה:

```json
{
  "name": "טופס פנייה",
  "description": "פנייה לרשות",
  "fields": [
    {
      "key": "fullName",
      "label": "שם מלא",
      "type": "Text",
      "required": true,
      "sortOrder": 0
    }
  ]
}
```
