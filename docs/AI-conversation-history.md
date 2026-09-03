<div dir="rtl" lang="he">

# היסטוריית התכתבות עם AI — מטלת בניית טפסים (רשות המיסים)

**כלי AI:** Cursor (מודל Grok / Cursor Grok 4.6)

**תאריכים:** 2–3 בספטמבר 2026

**שיחה:** [https://cursor.com/agents/bc-328aa3a6-ca5a-4b8a-8f82-e9e54f060d7c](https://cursor.com/agents/bc-328aa3a6-ca5a-4b8a-8f82-e9e54f060d7c)

המסמך הוא תמלול השיחה לצורך הגשת המבחן. הקוד נמצא ב-Git.

---

## הודעה 1 — משתמשת

יש לי מחר מטלת בית לצורך עבודה ברשות המיסים מפתח תוכנה רמה ג' עם ניסיון בשפות תכנות אנגולר .NET ו SQL תגיד לי מה אני יכולה לעשות כדי להתכונן למקסימום שנעבוד בצורה יעילה וזריזה מחר למטלת הבית, יש שעתיים למשימה ועד אז היא צריכה להיות מוכנה כקוד בגיט
אני לא רוצה שתתחיל לכתוב קוד לפני שאנחנו מסכמים מה ואיך הולך להיות, תחכה לאור ירוק ממני

## תשובה 1 — Cursor

את לא צריכה קוד עכשיו — קודם נסכם תוכנית לילה + יום המטלה. אני בודק מה ידוע על פורמט המטלות ברשות המיסים, ואז אציע הכנה מקסימלית בלי לגעת במשימה עצמה.

יש כבר תיקיית frontend בסביבה — בודק מה קיים בפועל, בלי לגעת בקוד המטלה.

יש כבר שלד ריק של Angular ו-.NET — אבדוק כמה הוא גנרי, בלי להרחיב אותו.

מחכה לאור ירוק. אין קוד מטלה, ואין commit.

יש כבר שלד ריק בסשן הזה: Angular 19 + ASP.NET Core 8 Web API. זה תבנית ברירת מחדל (`WeatherForecast`), בלי לוגיקה עסקית ובלי מסד נתונים. אפשר להשאיר אותו כבסיס או לזרוק — לפי מה שנחליט.

### מה כמעט בוודאות יגיע מחר

ברשות המיסים הסטאק הוא Angular + C#/.NET + SQL Server. מטלת בית של שעתיים לרמה ג' כמעט תמיד נראית כך:

- ישות אחת מרכזית (למשל תיק, דיווח, חשבונית, נישום, בקשה)
- CRUD מלא: רשימה, הוספה, עריכה, מחיקה
- ולידציה בצד שרת **וגם** בטופס Angular
- שאילתת SQL אמיתית: סינון, מיון, או JOIN — לא רק ORM עיוור
- Git עם README: איך מריצים, מה נבנה, החלטות קצרות

מה שבדרך כלל **לא** שווה זמן בשעתיים: התחברות, הרשאות מלאות, מיקרו-שירותים, CQRS, Docker, בדיקות יחידה בכל שכבה.

כלל ברזל: מסלול אחד שעובד מקצה לקצה עדיף על ארכיטקטורה יפה שלא רצה.

### מה אפשר להכין הלילה בלי לדעת את המטלה

שלוש שכבות. רק השלישית דורשת ממך אור ירוק.

**1. המחשב שלך (חובה, בלי קוד)**  
לוודא שמותקן ורץ: Node LTS, Angular CLI, .NET 8 SDK, Git, SQL Server Express או LocalDB, VS / VS Code. חשבון GitHub/Azure DevOps מוכן. ריפו ריק מחכה. לבדוק שאפשר ליצור פרויקט `webapi` ו-`ng new` בלי שגיאות.

**2. כללי משחק למחר (חובה)**  
ברגע שהמסמך נפתח:

1. לקרוא הכל עד הסוף לפני שכותבים שורה.  
2. לסמן חובה / נחמד / מלכודת זמן.  
3. לשלוח לי את המסמך כמו שהוא.  
4. לבנות קודם מודל נתונים + 3 מסכים, ורק אז קוד.  
5. לדחוף ל-Git מוקדם ובצורה מצטברת, לא בדקה 119.

**3. ערכת חימום גנרית (רק אם תאשרי)**  
לא פתרון למטלה, אלא שלד שאפשר למלא בשמות האמיתיים תוך דקות:

- API עם CORS, Swagger, טיפול שגיאות אחיד  
- EF Core מוכן ל-SQL Server, עם SQLite כגיבוי אם LocalDB נתקע  
- תיקיות ברורות: Controllers / Services / Models  
- Angular: `HttpClient`, טופס ריאקטיבי, טבלה, מצבי ריק/טעינה/שגיאה, RTL בעברית  
- `.gitignore` + שלד README

בלי זה, 20–40 הדקות הראשונות יישרפו על scaffolding.

### שעתיים — איך לא להיתקע

| דקות | מה עושים |
|------|----------|
| 0–10 | קריאה מלאה, סימון חובה, שליחה אליי |
| 10–20 | מודל טבלאות + חוזי API + רשימת מסכים |
| 20–55 | SQL + Web API + ולידציה. Swagger ירוק |
| 55–95 | Angular: רשימה + טופס + חיבור ל-API |
| 95–110 | תיקון באגים, מקרי קצה שביקשו במפורש |
| 110–120 | README, הרצה ידנית, `git push` |

אם ב־דקה 40 אין GET אחד שעובד — מצמצמים פיצ'רים, לא ממשיכים לעצב.

### איך נעבוד מחר

את שולחת את המטלה. אני מציע מבנה תוך כמה דקות. את מאשרת. אחר כך כותבים ביחד, שכבה־שכבה, עם קומיטים. בסוף את חייבת להבין כל שורה — בראיון ישאלו על בחירות, SQL, ולידציה וזרימת הנתונים.

לפני זה כדאי לבדוק במסמך אם מותר סיוע / AI. אם אסור — נכין רק שלד ותכנית, ואת תכתבי לבד.

### מה אני מבקש ממך עכשיו

אור ירוק / אדום על אלה:

1. **להכין הלילה ערכת חימום גנרית** בסשן הזה, בלי לוגיקה של רשות המיסים?  
2. **SQL Server או SQLite כברירת מחדל?** המלצה: SQL Server אם יש לך LocalDB; SQLite רק כרשת ביטחון.  
3. **Angular Material או UI פשוט?** בשעתיים — UI נקי בלי ספרייה כבדה, אלא אם המטלה דורשת Material.  
4. **האם מותר לי לכתוב איתך את הקוד מחר**, או רק לתכנן ואת מממשת?

ברגע שתגידי מה מאשרים — מתחילים רק בזה. בלי מטלה אמיתית עד מחר.

---

## הודעה 2 — משתמשת

מבחן מקצועי FULLSTACK.docx 
מצרפת לך את המטלה,
לפני שאנחנו מתחילים לכתוב קוד אני רוצה שתסכם באיזה מבנה הקוד הולך להיות בנוי וכן באיזה טכנולוגיות להשתמש, כמובן בהכי חדישות שיש אנגולר 20 ו .NET 8 מסד נתונים- תמליץ לי מה הכי מומלץ ונכון למשימה הזו,
חשוב לי לציין שכרגע אין לי על המחשב שום תוכנת פיתוח, אבל אני יתקין מה שצריך בשביל לראות ולהריץ את הפרויקט מהצד שלי
אז דבר ראשון נתחיל בניתוח המטלה

## תשובה 2 — Cursor

קורא את המטלה מקצה לקצה, ואז אסכם מבנה, טכנולוגיות ומסד נתונים — בלי לכתוב קוד.

המטלה ברורה, והדגש שלה הוא **לא** CRUD רגיל. בודקים אותך על מידול של מידע לא אחיד, SQL, שכבות, ולידציה של החלטות — והקוד הוא הוכחה שהחשיבה עובדת.

זמן רשמי: **3 שעות**. AI מותר, אבל את חייבת להסביר כל בחירה, וצריך לצרף היסטוריית שיחה + לציין באיזה כלי השתמשת.

---

### מה באמת צריך לממש בקוד

המסמך מפריד בין **תכנון** לבין **פיתוח**:

| חלק | חובה בקוד? | מה כן |
|-----|-------------|--------|
| מסך 1 — שיטות פרמיה | לא ב-Angular | API מלא + אפיון/סקיצה |
| מסך 2 — מדדים | לא ב-Angular | API מלא + אפיון/סקיצה |
| **מסך 3 — קליטה וצפייה** | **כן, זה כל ה-UI** | העלאת Excel, טבלה דינמית, סינון, מיון, כמויות |
| Backend | כן, מלא | שיטות, מדדים, קליטת קובץ, היסטוריה, שליפת נתונים, רשימת שדות/סינונים |
| מסמך אפיון, ERD, חלופות, תרחיש Excel | כן | Word/PDF במייל |
| סרטון | כן | מערכת חיה + הסבר טכנולוגיות + טבלאות + המודל הדינמי |

עיצוב מושלם לא נדרש. פונקציונליות ולוגיקה חשובים יותר מ-CSS.

---

### הבעיה המרכזית

שיטת פרמיה → כמה מדדים → לכל מדד קובץ Excel **במבנה אחר**.

שדות שונים, טיפוסים שונים, לא הכול רלוונטי, המבנה ישתנה, מדדים חדשים יתווספו — **בלי לשנות סכמת DB משמעותית**. בנוסף: היסטוריית קליטות, שנה+תקופה לכל קובץ, וצפייה דינמית עם סינון/מיון על נפח גדול.

שלוש דוגמאות מהמטלה (עובדים / שעות / מכירות) הן בדיוק מקרי הבדיקה שנזרע ונעלה בסרטון.

---

### חלופות למידע הלא הומוגני (זה לב המבחן)

#### חלופה א' — טבלה לכל מדד
עובדים, שעות, מכירות כטבלאות נפרדות עם עמודות קבועות.

- יתרון: SQL פשוט, טיפוסים טבעיים, אינדקסים, ביצועים מעולים.
- חיסרון: מדד חדש = טבלה חדשה. שינוי Excel = migration. נכשל בדרישת הגמישות.
- מורכבות פיתוח/תחזוקה: נמוכה בהתחלה, גבוהה מאוד לאורך זמן.
- חיפוש: מצוין. גמישות: גרועה.

נפסלת כפתרון ראשי. נזכיר אותה במסמך כחלופה שנפסלה במודע.

#### חלופה ב' — EAV (שורה לכל ערך)
`DataRow` + `DataValue(FieldId, Value)`.

- יתרון: גנרי לגמרי, בלי שינוי סכמה, אפשר לאנדקס לפי שדה.
- חיסרון: פיצוץ שורות, JOIN כבד, הטבלה "הרחבה" נהיית שאילתה קשה, טיפוסים מתערבבים (הכול מחרוזת או כמה עמודות Value).
- מורכבות: גבוהה. ביצועים: נחלשים מהר על נפח. חיפוש: אפשרי אבל יקר. גמישות: גבוהה.

#### חלופה ג' (מומלצת) — קטלוג רלציוני + JSON לשורות

שתי שכבות:

1. **מטא-דאטה רלציוני קשיח** — שיטות, מדדים, שדות רלוונטיים, קליטות. כאן SQL אמיתי, מפתחות, אינדקסים.
2. **הנתונים עצמם** — שורה בקובץ = שורה ב-DB עם עמודת JSON (`Payload`).

למה זה הפתרון למבחן הזה:

- מדד חדש = שורות בקטלוג, לא טבלה חדשה.
- שינוי Excel = עדכון מיפוי שדות, לא migration.
- היסטוריה: כל קליטה שומרת צילום של הכותרות (`SchemaSnapshot`).
- נתונים ישנים נשארים תקינים (ב-JSON פשוט אין את המפתחות החדשים).
- UI דינמי נבנה מ-`MetricField`, לא מקוד מקובע.
- בשאילתה: פגינציה/מיון/סינון בשרת; ב-SQLite יש `json_extract` (וב-SQL Server זה היה `JSON_VALUE` / `OPENJSON` — אותו מודל).
- בשלוש שעות זה בר-מימוש, ועדיין נשמע כמו החלטה של ארכיטקטית ולא קיצור דרך.

חיסרון שנגיד ביושר: סינון על שדה JSON חלש יותר מעמודה רגילה. לכן נסמן בקטלוג אילו שדות ניתנים לסינון, נסנן רק עליהם, ונאנדקס `(MetricId, Year, Period)` + `IngestionId`. אם בעתיד שדה הופך לכבד — מוציאים אותו לאינדקס ייעודי בלי לשבור את המודל.

**הבחירה: חלופה ג'.** EAV כחלופה שנייה מפורטת. טבלה-למדד כחלופה שנפסלה.

---

### מבנה ה-Database

SQLite **כי המטלה מחייבת אותו**. לא SQL Server למבחן. המודלים, FK והאינדקסים יהיו כאילו זה SQL Server, כדי שמעבר עתידי יהיה החלפת connection string + ספק EF.

```text
PremiumMethod 1──* Metric 1──* MetricField
                    │
                    └──* Ingestion 1──* DataRow
                         (Payload JSON)
```

**PremiumMethod** — מספר שיטה (ייחודי), תיאור, אחוז פרמיה, סוג תקופת חישוב (חודש/רבעון).

**Metric** — שם, תיאור, סוג מקור (`Excel` / `ExternalInterface`), שם מקור, תדירות קליטה. בשלב זה מממשים רק Excel; ה-enum משאיר פתח בלי לשכתב DB.

**MetricField** — זה הלב: אילו שדות רלוונטיים למדד. מפתח יציב (`employeeId`), כותרת Excel, שם תצוגה, טיפוס (`string/number/date`), חובה, ניתן לסינון/מיון, סדר תצוגה, פעיל. שינוי מבנה קובץ = שדות חדשים כאן, הישנים נשארים בשביל היסטוריה.

**Ingestion** — קליטה אחת: מדד, שנה, תקופה, שם קובץ, סטטוס, מספר שורות, זמן, שגיאה, **צילום מבנה** (כותרות + מיפוי באותו רגע).

**DataRow** — `IngestionId`, `MetricId` (מפורק לשליפה), מספר שורה, `Payload` JSON.

אינדקסים מרכזיים: מספר שיטה; מדד לפי שיטה; שדות לפי מדד; קליטות לפי מדד+שנה+תקופה; שורות לפי קליטה וגם לפי מדד.

אין טבלת "עובדים" / "מכירות". זה בדיוק מה שנמנעים ממנו.

---

### תהליך העבודה במערכת

1. מגדירים שיטת פרמיה (מספר, אחוז, תקופת חישוב).
2. משייכים מדדים ומגדירים מקור Excel.
3. מגדירים שדות רלוונטיים וממפים אותם לכותרות בקובץ.
4. מעלים קובץ לשנה+תקופה.
5. השרת קורא כותרות, משווה לקטלוג, בודק שדות חובה, שומר קליטה + snapshot + שורות JSON.
6. מסך 3 שולף קודם מטא-דאטה של שדות, ואז נתונים עם עמוד/מיון/סינון — והטבלה נבנית בזמן ריצה.

תרחיש "נוספו עמודות מנהל ישיר ומיקום": המערכת מזהה כותרות חדשות בקובץ. DB לא משתנה. קוד הפרסר הגנרי לא משתנה. כן נדרשת הגדרה: להוסיף שני `MetricField`. קליטות ישנות נשארות; בשורות הישנות השדות החדשים ריקים. ההיסטוריה יושבת ב-`SchemaSnapshot` של כל קליטה.

---

### טכנולוגיות

| שכבה | בחירה | למה |
|------|--------|-----|
| UI | **Angular 20**, standalone, Reactive Forms, Signals | כפי שביקשת; המטלה דורשת Reactive Forms וניהול state. בלי NgRx — בשלוש שעות זה רעש. state = שירותים + signals |
| API | **ASP.NET Core 8** Web API | כפי שביקשת וכפי שהמטלה דורשת |
| ORM | EF Core 8 | מיגרציות, מודלים ברורים, מתאים ל-SQLite ול-SQL Server |
| DB | **SQLite** | חובה במבחן. קובץ ליד ה-API, בלי להתקין שרת DB |
| Excel | ClosedXML | קריאת `.xlsx` עם כותרות בעברית, בלי רישיון מסובך |
| UI kit | בלי Material/PrimeNG | המטלה אמרה במפורש שעיצוב לא נמדד. HTML/CSS נקי, RTL |

שכבות בצד שרת (פרויקט אחד, תיקיות ברורות — לא 5 פרויקטים):

```text
backend/PremiumApi
  Domain/          ישויות + enums
  Data/            DbContext, קונפיגורציות, מיגרציות
  Services/        שיטות, מדדים, קליטה, שליפה
  Dtos/
  Controllers/
```

OOP שנראה במבחן: ממשק `IIngestionStrategy` (Excel עכשיו, ממשק חיצוני אחר כך), פרסר Excel מופרד משמירה, שירות שליפה שלא יודע מה זה "עובדים".

צד לקוח — **רק מסך 3**, אבל עם בחירת שיטה/מדד (dropdown מה-API) כדי שהזרימה תיסגר:

```text
frontend/src/app
  core/            API, interceptors
  features/ingest/ מסך 3: העלאה, היסטוריה, טבלה דינמית
  shared/          טבלה, פאג'ינציה, הודעות שגיאה
```

הטבלה והפילטרים נבנים מ-`GET /api/metrics/{id}/fields`. ה-FormGroup הדינמי הוא בדיוק מה שהם רוצים לראות ב-Reactive Forms.

---

### מה להתקין אצלך (בלי Visual Studio, בלי SQL Server)

הפרויקט ירוץ אצלך עם:

1. **Git** — [git-scm.com](https://git-scm.com)
2. **Node.js 22 LTS** — [nodejs.org](https://nodejs.org) (Angular 20 דורש Node 20+)
3. **.NET 8 SDK** — [dot.net](https://dotnet.microsoft.com/download/dotnet/8.0)
4. **VS Code** — הרחבות: C# Dev Kit, Angular Language Service
5. אופציונלי: [DB Browser for SQLite](https://sqlitebrowser.org) כדי לראות טבלאות בסרטון

לא צריך: Visual Studio, SQL Server, SSMS, IIS. אחרי clone:

```bash
cd backend/PremiumApi && dotnet run
cd frontend && npm start
```

קובץ ה-SQLite נוצר אוטומטית.

---

### איך נחלק את שלוש השעות מחר

1. DB + seed לשלושת המדדים מהמטלה  
2. API (Swagger ירוק)  
3. מסך 3: העלאה + טבלה דינמית + סינון/מיון/עמוד  
4. מסמך אפיון (ERD, חלופות, תרחיש Excel, API)  
5. Git + בדיקה ידנית. הסרטון אצלך בסוף

מסכים 1–2: סקיצה במסמך + הפעלה דרך Swagger. אם יישאר זמן — נרחיב UI. לא בהתחלה.

---

אם המבנה הזה מאושר — בשלב הבא מתחילים קוד לפי הסדר הזה, בלי להוסיף auth, NgRx, או מסכים מיותרים. אם תרצי לשנות משהו (EAV במקום JSON, Angular Material, גם מסכים 1–2 בקוד) — תגידי לפני שמתחילים.

---

## הודעה 3 — משתמשת

המבחן מעשי.docx
מצרפת את המטלה הנכונה אני רוצה שננתח אותה בצורה המדויקת ביותר ואז תיצור פרויקטים עם כל הקוד הרלוונטי 
אבל לפני זה נסכם על מבנה נכון תקני מתקדם, מסודר וברור

## תשובה 3 — Cursor

קורא את המטלה הנכונה מקצה לקצה, ואז אסכם מבנה מדויק לפני כל כתיבת קוד.

יש תרשים במסמך — אחלץ אותו כדי שהניתוח יסתמך על מה שכתוב שם, לא על המטלה הקודמת.

זו **מטלה אחרת לגמרי** מהקובץ הקודם. הקודם היה שיטות פרמיה ו-Excel. כאן: **PoC לבניית טפסים + אבני דרך** למחלקת הון אנושי. כל התכנון הקודם נזרק.

לא כותבת קוד עד שתאשרי את המבנה למטה.

---

### מה המבחן בודק בפועל

PoC של שעתיים–שלוש, לא מערכת HR מלאה. שלושה תוצרים:

1. **קוד** — Angular + .NET API + EF Core, ב-Git.
2. **מסך אחד** — «יצירת טופס חדש» (שם, שדות דינמיים, אבני דרך).
3. **סרטון** — הדגמה חיה + למה בחרנו בטבלאות האלה + מענה בעל פה לחלק 3 (ענן, GenAI, אינטגרציה).

AI מותר. חובה לציין שזה Cursor, ולצרף את היסטוריית השיחה.

עיצוב לא נמדד. נמדדים: מודל רלציוני, שכבות, OOP, Reactive Forms, ושמירת הטופס **בשלמותו** (שדות + מסלול) בטרנזקציה אחת.

---

### היקף מדויק — מה כן ומה לא

**Backend — בדיוק 3 פעולות:**

- `POST` שמירת טופס חדש בשלמותו  
- `GET` רשימת טפסים  
- `GET` טופס לפי מזהה  

**Angular — מסך יצירה בלבד:**

- שם הטופס  
- בונה שדות: כפתורים «הוסף שדה טקסט» / «הוסף שדה תאריך» (בלי Drag & Drop)  
- אבני דרך: הוספה/הסרה, לכל שלב לפחות שם + סוג פעולה  

**לא בפיתוח (רק דיבור בסרטון):** ענן היברידי, צ'אט GenAI, אינטגרציה ל-On-Premise.

**לא בונים:** התחברות, הרשאות, מילוי טופס על ידי עובד, שליחת אישור אמיתית, Drag & Drop, Material כחובה.

כדי שהסרטון לא יישבר: מתחת לטופס היצירה תהיה **רשימה לקריאה בלבד** של טפסים שנשמרו. זה עדיין מסך אחד, ומוכיח את שלושת ה-API.

---

### החלטה ארכיטקטונית מרכזית: איך שומרים טופס דינמי

המטלה נותנת שתי דרכים: שורות שדות **או** HTML גולמי.

| | שדות כטבלה רלציונית | מחרוזת HTML |
|--|---------------------|-------------|
| מודל DB | 1:N אמיתי, מה שהם רוצים לראות ב-EF | עמודה אחת, חלש למבחן רלציוני |
| Angular | `FormArray` — בדיוק Reactive Forms | textarea, כמעט אין state |
| OOP | `FieldType` enum, ישויות ברורות | מחרוזת |
| אבטחה | אין XSS | חייבים sanitize |
| הרחבה | שדה מספר/חובה בקלות | parsing שביר |

**בוחרים במודל רלציוני של שדות.** לא שומרים HTML. אם ישאלו בסרטון: HTML מהיר יותר לפרוטוטייפ ויזואלי, אבל שובר שאילתות, ולידציה ו-XSS; למחלקת הון אנושי עדיף קטלוג שדות.

אבני הדרך **תמיד** טבלה נפרדת — זה דרישה מפורשת (סדר, שם, זהות מאשר, סוג פעולה).

---

### מסד הנתונים

SQLite + EF Core (כמו שהמטלה ממליצה). In-Memory נפסל כי אחרי restart בסרטון הנתונים נעלמים. המודלים כאילו SQL Server: FK, cascade, אינדקסים.

```text
FormTemplate  1──*  FormField
      │
      └──*  ApprovalStep
```

**FormTemplate** (מעטפת)  
`Id`, `Name`, `CreatedAt`, `CreatedBy`

**FormField** (המבנה הדינמי)  
`Id`, `FormTemplateId`, `SortOrder`, `Label`, `FieldType` (Text / Date), `IsRequired`

**ApprovalStep** (מסלול אישורים)  
`Id`, `FormTemplateId`, `StepOrder`, `Name`, `ApproverIdentity`, `ActionType` (Approve / Reject / ApproveOrReject)

קשרים: מחיקת תבנית מוחקת שדות ושלבים (`Cascade`).  
אינדקסים: `(FormTemplateId, SortOrder)`, `(FormTemplateId, StepOrder)`.

אין טבלת Users. «זהות המאשר» במבחן = טקסט (שם/מספר עובד). טבלת עובדים הייתה נכונה למערכת אמיתית, ובשלוש שעות זה עוד CRUD שלא נדרש.

שמירה: `POST` אחד, DTO מקונן, טרנזקציה אחת. זה «הטופס בשלמותו».

---

### מבנה הריפו (זה מה שצריך לאשר)

לא Clean Architecture של 5 פרויקטים — זה תיאטרון בשלוש שעות. כן שכבות ברורות, OOP, ותיקיות שמראיינת ממשלתית מצפה לראות.

```text
/
  README.md                 הרצה + איזה AI + נקודות לסרטון
  docs/part3-talking-points.md
  backend/
    HrForms.sln
    src/HrForms.Domain/           ישויות + enums בלבד
    src/HrForms.Application/      ממשקים, DTOs, שירות, ולידציה
    src/HrForms.Infrastructure/   EF Core, SQLite, Fluent API
    src/HrForms.Api/              Controllers, Program, CORS, Swagger
  frontend/                     Angular 20
    src/app/
      core/                     Http, models, interceptors
      features/form-builder/    המסך היחיד
        form-builder.page.ts
        field-list/
        milestone-list/
        template-list/
      shared/
```

**למה 4 פרויקטים ב-.NET:**  
Domain בלי תלות ב-EF. Application מגדיר *מה* נשמר. Infrastructure *איך*. Api רק HTTP. זו «חלוקה נכונה לשכבות» שאפשר להסביר במשפט בסרטון.

**Angular 20:** standalone, Reactive Forms, `FormArray` לשדות ולשלבים, Signals ל-loading/error/רשימה. בלי NgRx (מוגזם למסך אחד). בלי Angular Material — UI נקי RTL, כמו שהמטלה ביקשה.

**זרימת נתונים:**

```text
מסך (FormGroup)
  → FormTemplateService (Angular)
    → POST /api/form-templates
      → FormTemplatesController
        → IFormTemplateService
          → טרנזקציה: Template + Fields + Steps
            → SQLite
```

לאחר הצלחה: איפוס הטופס + רענון הרשימה (`GET`).

---

### חוזי API

`POST /api/form-templates`  
גוף: `{ name, createdBy, fields: [{ label, fieldType, isRequired, sortOrder }], steps: [{ name, approverIdentity, actionType, stepOrder }] }`

`GET /api/form-templates` — רשימה קצרה (id, name, createdAt, מספר שדות, מספר שלבים)

`GET /api/form-templates/{id}` — הטופס המלא כולל שדות ושלבים

ולידציה בשרת (חובה) וגם ב-Angular: שם טופס חובה; לפחות שדה אחד; לפחות אבן דרך אחת; תווית לכל שדה; שם לכל שלב. בלי זה השמירה «בשלמותו» ריקה מתוכן.

---

### מה להתקין אצלך

Git, Node.js 22 LTS, .NET 8 SDK, VS Code (C# Dev Kit + Angular Language Service).  
לא Visual Studio, לא SQL Server. SQLite הוא קובץ שנוצר בהרצה.

---

### חלק 3 — כיוון תשובה לסרטון (לא קוד)

1. **ענן היברידי:** Angular מאחורי Front Door/WAF (ציבורי). API ו-DB ברשת פרטית. חיבור לארגון ב-VPN/ExpressRoute. נתונים רגישים נשארים On-Prem; הענן קורא דרך gateway, לא פותחים SQL לאינטרנט.  
2. **GenAI:** הצ'אט ב-Angular, המודל **רק דרך ה-API** (מפתח לא בדפדפן). ה-AI מחזיר JSON של שדות לפי סכמה, לא HTML חופשי. State = מזהה שיחה + טיוטת הטופס. לפני תצוגה: ולידציית סכמה + allowlist של סוגי שדות. אם בכל זאת HTML — DOMPurify + CSP, בלי `<script>`.  
3. **אינטגרציה:** תבנית «מפורסמת» נשלחת למערכת הישנה דרך תור (Service Bus) או API גרסאי, עם מזהה יציב ו-idempotency. לא גישה ישירה למסד של המערכת הישנה.

---

אם המבנה הזה מאושר — בשלב הבא בונים את ארבעת פרויקטי ה-.NET ואת Angular 20, עם כל הקוד שעובד מקצה לקצה: יצירת טופס, שדות, אבני דרך, שמירה, רשימה, שליפה. בלי auth, בלי Material, בלי HTML גולמי.

---

## הודעה 4 — משתמשת

ממש לא, דבר ראשון נתחיל במה צריך להתקין בשביל שנוכל להריץ את הפרויקט, ואחכ נעבור שלב שלב מהחלק של איך נכון לשמור את הנתונים כרגע בלי מסד נתונים לאחר מכן שכבת הסרבר איך תהיה בנויה ורק בסוף האנגולר

## תשובה 4 — Cursor

מתחילים מההתקנות בלבד, ואחר כך — בלי מסד — איך הנתונים יישמרו בזיכרון. בלי קוד ובלי Angular עד שנסגור את זה.

### 1. מה להתקין אצלך

אין צורך ב-Visual Studio, SQL Server, SSMS או IIS. הפרויקט ירוץ עם ארבעה דברים + עורך.

אם יש לך Windows 10/11, הכי מהיר מ-PowerShell **כמנהל**:

```powershell
winget install Git.Git
winget install OpenJS.NodeJS.LTS
winget install Microsoft.DotNet.SDK.8
winget install Microsoft.VisualStudioCode
```

אחרי זה **לסגור את כל חלונות הטרמינל** ולפתוח מחדש. בדיקה:

```powershell
git --version
node -v
npm -v
dotnet --version
```

מה שצריך לראות בערך:

| כלי | גרסה תקינה |
|-----|------------|
| Git | 2.x |
| Node | **22** (או לפחות 20.19) — Angular 20 לא ירוץ על 18 |
| npm | מגיע עם Node |
| .NET SDK | **8.0.x** — חשוב SDK, לא Runtime לבד |

אם `winget` לא קיים, התקנה ידנית לפי הסדר הזה:

1. **Git** — https://git-scm.com/download/win  
2. **Node.js 22 LTS** — https://nodejs.org (לא Current אם הוא 24 ויוצר בלגן; LTS מספיק)  
3. **.NET 8 SDK** — https://dotnet.microsoft.com/download/dotnet/8.0  
   לבחור SDK, x64 (רוב המחשבים), לא ASP.NET Runtime בלבד  
4. **VS Code** — https://code.visualstudio.com  

ב-VS Code להתקין שתי הרחבות:

- **C# Dev Kit** (Microsoft)  
- **Angular Language Service** (Angular)

אופציונלי, אחרי ש-Node עובד:

```powershell
npm install -g @angular/cli@20
ng version
```

לא חובה גלובלית — אפשר גם `npx`. נוח ש-`ng` עובד אצלך בסרטון.

**חשבון GitHub** (או GitLab) — ההגשה היא קישור למאגר. בלי זה הקוד אצלך רק מקומית.

לא מתקינים: SQL Server, LocalDB, Docker, Visual Studio Community. לא בשלב הזה.

כשארבע הפקודות למעלה מדפיסות גרסה — כתבי «ההתקנות עובדות» ונעבור למימוש. בינתיים רק הסיכום של השלב הבא, בלי קוד.

---

### 2. שמירת נתונים עכשיו — בלי מסד

אין קובץ `.db`, אין SQL, אין מיגרציות. יש **אובייקטים בזיכרון של השרת**.

למבחן זה לגיטימי: הם עצמם כתבו In-Memory או SQLite, כל עוד היחסים נכונים כמו ב-SQL Server.

**הרעיון:** טופס אחד הוא מקבץ אחד בזיכרון, לא שלוש «טבלאות» נפרדות בלי קשר.

```text
FormTemplate                ← הטופס (מעטפת)
  Name, CreatedAt, CreatedBy
  Fields[]                  ← השדות שהמשתמש הוסיף
  Steps[]                   ← אבני הדרך
```

שדה אחד: תווית, סוג (טקסט/תאריך), האם חובה, סדר.  
אבן דרך אחת: שם שלב, זהות מאשר, סוג פעולה, סדר.

**איפה זה חי:** מחלקה אחת בשרת — מאגר — שמחזיקה רשימה:

```text
רשימת FormTemplate בזיכרון
  הוספה = שמירת טופס בשלמותו (המעטפת + השדות + השלבים ביחד)
  שליפת הכל = רשימה
  שליפה לפי Id = טופס מלא
```

למה זה «נכון» ולא משתנה גלובלי בקונטרולר:

- הקונטרולר לא שומר נתונים. הוא מקבל HTTP ומעביר הלאה.  
- המאגר הוא המקום היחיד שרואה את הרשימה.  
- מחר מחליפים את המאגר ב-EF/SQLite בלי לגעת ב-API.  
- שמירה בשלמותו = מוסיפים ל רשימה אובייקט שכבר מכיל את השדות והשלבים. אין «קודם טופס, אחר כך שדות בנפרד».

הנתונים נמחקים כשעוצרים את השרת. ל-PoC ולסרטון זה בסדר: מדגימים יצירה, רואים ברשימה, פותחים לפי Id. בסרטון אומרים במפורש: זה In-Memory במכוון; המודל זהה לטבלאות, בלי התקנת DB.

לא שומרים HTML. לא שומרים ב-`localStorage` בדפדפן — אז אין שרת אמיתי.

---

### 3. השרת — רק אחרי שהמאגר ברור

שכבה דקה מעל המאגר, עדיין בלי Angular:

```text
HTTP → Controller → Service → מאגר בזיכרון
```

- **Controller** — שלוש פעולות: POST מלא, GET רשימה, GET לפי id  
- **Service** — ולידציה (שם, לפחות שדה, לפחות שלב) והרכבת האובייקט  
- **מאגר** — הרשימה בזיכרון  

פרויקט .NET אחד בשלב הזה. לא ארבעה פרויקטים. Swagger כדי לבדוק את ה-API בדפדפן לפני שיש UI.

---

### 4. Angular

רק אחרי שה-POST/GET עובדים ב-Swagger. לא עכשיו.

---

סדר העבודה מכאן: התקנות → מאגר בזיכרון + מחלקות → API + Swagger → רק אז מסך Angular.

אם משהו נכשל ב-`dotnet --version` / `node -v`, שלחי את הפלט. אם הכול ירוק — נתחיל במחלקות ובמאגר, בלי מסד ובלי Angular.

---

## הודעה 5 — משתמשת

winget install Git.Git
Failed when searching source: msstore
An unexpected error occurred while executing the command:
0x8a15005e : The server certificate did not match any of the expected values.

The following packages were found among the working sources.
Please specify one of them using the --source option to proceed.
Name Id      Source
-------------------
Git  Git.Git winget

C:\Users\User>winget install OpenJS.NodeJS.LTS
Failed when searching source: msstore
An unexpected error occurred while executing the command:
0x8a15005e : The server certificate did not match any of the expected values.

The following packages were found among the working sources.
Please specify one of them using the --source option to proceed.
Name          Id                Source
--------------------------------------
Node.js (LTS) OpenJS.NodeJS.LTS winget

C:\Users\User>
זה התשובות של ההרצה

## תשובה 5 — Cursor

זו לא בעיה ב-Git או ב-Node. מקור ה-Microsoft Store אצלך נכשל על תעודה, ו-winget מפסיק במקום להמשיך. החבילות עצמן נמצאו במקור `winget`.

להריץ שוב, עם מקור מפורש:

```powershell
winget install Git.Git --source winget --accept-package-agreements --accept-source-agreements
winget install OpenJS.NodeJS.LTS --source winget --accept-package-agreements --accept-source-agreements
winget install Microsoft.DotNet.SDK.8 --source winget --accept-package-agreements --accept-source-agreements
winget install Microsoft.VisualStudioCode --source winget --accept-package-agreements --accept-source-agreements
```

אם יבקש הרשאות מנהל — לאשר. אחרי ארבעתן: **לסגור את CMD/PowerShell לגמרי**, לפתוח חלון חדש, ואז:

```powershell
git --version
node -v
npm -v
dotnet --version
```

שלחי את ארבע השורות שיוצאות. אם אחת נכשלת — את הודעת השגיאה שלה בלבד.

---

## הודעה 6 — משתמשת

יש לי בעיה שנראה שחסום לי במחשב להתקין כי המחשב של העבודה ונראה שחסמו את האפשרות, יש דרך לעקוף את זה או שיש אפשרות ליצור את הפרויקטים ולהריץ אותה ב IDE שלך

## תשובה 6 — Cursor

_לא נשלחה תשובה נפרדת; ההודעה הבאה המשיכה את אותו נושא._

---

## הודעה 7 — משתמשת

יש לי בעיה שנראה שחסום לי במחשב להתקין כי המחשב של העבודה ונראה שחסמו את האפשרות, יש דרך לעקוף את זה או שיש אפשרות ליצור את הפרויקטים ולהריץ אותה ב IDE שלך
winget install Git.Git --source winget --accept-package-agreements --accept-source-agreements
Found Git [Git.Git] Version 2.55.0.3
This application is licensed to you by its owner.
Microsoft is not responsible for, nor does it grant any licenses to, third-party packages.
Downloading https://github.com/git-for-windows/git/releases/download/v2.55.0.windows.3/Git-2.55.0.3-64-bit.exe
  ██████████████████████████████  62.3 MB / 62.3 MB
Successfully verified installer hash
Starting package install...
The installer will request to run as administrator. Expect a prompt.
Successfully installed

C:\Users\User>winget install OpenJS.NodeJS.LTS --source winget --accept-package-agreements --accept-source-agreements
Found Node.js (LTS) [OpenJS.NodeJS.LTS] Version 24.19.0
This application is licensed to you by its owner.
Microsoft is not responsible for, nor does it grant any licenses to, third-party packages.
Downloading https://nodejs.org/dist/v24.19.0/node-v24.19.0-x64.msi
  ██████████████████████████████  31.4 MB / 31.4 MB
Successfully verified installer hash
Starting package install...
The installer will request to run as administrator. Expect a prompt.
You cancelled the installation.
Installer failed with exit code: 1602
Installer log is available at: C:\Users\User\AppData\Local\Packages\Microsoft.DesktopAppInstaller_8wekyb3d8bbwe\LocalState\DiagOutputDir\OpenJS.NodeJS.LTS.24.19.0-26-09-03-10-39-44.log

C:\Users\User>winget install Microsoft.DotNet.SDK.8 --source winget --accept-package-agreements --accept-source-agreements
Found Microsoft .NET SDK 8.0 [Microsoft.DotNet.SDK.8] Version 8.0.424
This application is licensed to you by its owner.
Microsoft is not responsible for, nor does it grant any licenses to, third-party packages.
Downloading https://download.microsoft.com/download/6141e558-e0ef-473c-8dc2-122d381f9bc8/988b5e46-33a0-4cfe-8fb1-d8b90ec1d280/dotnet-sdk-8.0.424-win-x64.exe
  ██████████████████████████████   215 MB /  215 MB
Successfully verified installer hash
Starting package install...
You cancelled the installation.
Installer failed with exit code: 1602
Installer log is available at: C:\Users\User\AppData\Local\Packages\Microsoft.DesktopAppInstaller_8wekyb3d8bbwe\LocalState\DiagOutputDir\Microsoft.DotNet.SDK.8.8.0.424-26-09-03-10-41-13.log

## תשובה 7 — Cursor

אין צורך לעקוף את מדיניות המחשב בעבודה — נבנה ונריץ כאן. קודם אבדוק מה כבר זמין בסביבה, ואז אתחיל בשרת עם שמירה בזיכרון, בלי Angular.

אין צורך לעקוף את המחשב בעבודה — Git כבר הותקן, ו-Node/.NET נעצרו כי בוטל חלון המנהל. נבנה ונריץ את השרת כאן, עם שמירה בזיכרון.

אין צורך לעקוף את המחשב בעבודה, וגם לא כדאי: זה מחשב ארגוני, ו-1602 אומר שההתקנה בוטלה בחלון המנהל (UAC), לא ש-Git נכשל. Git כן הותקן. Node ו-.NET נעצרו ברגע שבוטל האישור.

כאן אין את המגבלה הזו. בניתי את השרת והוא רץ בסביבה הזו. אפשר לפתוח Swagger, לשמור טופס, לראות רשימה ולשלוף לפי מזהה — בלי להתקין אצלך כלום.

השרת בנוי כמו שסיכמנו, בלי מסד ובלי Angular:

`HTTP → Controller → Service → מאגר בזיכרון`

- `POST /api/form-templates` — טופס שלם (שדות + אבני דרך) בבקשה אחת  
- `GET /api/form-templates` — רשימה  
- `GET /api/form-templates/{id}` — טופס מלא  

בדקתי: שמירה ריקה נחסמת, טופס «בקשת חופשה» נשמר, הרשימה והשליפה לפי id מחזירות אותו. הנתונים נמחקים כשעוצרים את השרת — זה מכוון בשלב הזה.

ב-Swagger: `POST /api/form-templates` → Try it out. דוגמה לגוף:

```json
{
  "name": "בקשת חופשה",
  "createdBy": "תמר",
  "fields": [
    { "label": "תאריך התחלה", "fieldType": "Date", "isRequired": true },
    { "label": "סיבת הבקשה", "fieldType": "Text", "isRequired": false }
  ],
  "steps": [
    { "name": "אישור מנהל ישיר", "approverIdentity": "123456789", "actionType": "ApproveOrReject" }
  ]
}
```

`fieldType`: `Text` או `Date`.  
`actionType`: `Approve`, `Reject`, או `ApproveOrReject`.

אם בהמשך יהיה מחשב בלי חסימה (או הרשאת מנהל ותלחצי Yes), אפשר יהיה להריץ גם אצלך. למבחן אפשר להמשיך מכאן: להדגים ב-Swagger, ואחר כך Angular.

השלב הבא אחרי שתאשרי: מסך Angular מחובר ל-API הזה.

> כרטיסיית תצוגה מקדימה בסביבת Cursor «HR Forms API» — Swagger של השרת: שמירת טופס, רשימה, ושליפה לפי מזהה. בלי מסד נתונים. (כתובת פנימית: `http://127.0.0.1:43142/swagger` — נפתחת מ-Preview, לא מדפדפן המחשב בעבודה.)

---

## הודעה 8 — משתמשת

אני רוצה שתסביר לי מדויק איך אני יכולה לראות את הפרויקטים שיצרתי ונתכתב דרך שם, דרך ה IDE שלך

## תשובה 8 — Cursor

אסביר בדיוק איך לראות את הקבצים ולהמשיך את השיחה מכאן — בודק את מסך הסוכן ואת תיעוד Cursor כדי שההוראות יהיו מדויקות.

את כבר בתוך ה-IDE שלי. השיחה הזו רצה על מחשב מרוחק של Cursor, לא על המחשב בעבודה. הקבצים נמצאים שם. אין צורך להתקין Node או .NET אצלך כדי לראות ולהמשיך לדבר.

### איפה נכנסים

בחר אחת:

**בדפדפן** (הכי פשוט מהמחשב בעבודה):  
[https://cursor.com/agents/bc-328aa3a6-ca5a-4b8a-8f82-e9e54f060d7c](https://cursor.com/agents/bc-328aa3a6-ca5a-4b8a-8f82-e9e54f060d7c)

התחברי לאותו חשבון Cursor. הסוכן נקרא **מטלת רשות המיסים**.

**באפליקציית Cursor במחשב:**

1. `Ctrl+Shift+P` (במק: `Cmd+Shift+P`)
2. **Open Agents Window**
3. ברשימה בצד: **מטלת רשות המיסים**

אם את כותבת לי עכשיו מהטלפון או מהאתר — זה אותו שיחה. ממשיכים כאן, בלי לפתוח סוכן חדש.

### איך רואים את הקבצים

בחלון הסוכן:

- בצד ימין / למטה: לשונית **Changes** (או כפתור עם מספר השינויים). שם עץ הקבצים וה-diff.
- חיפוש קובץ: `Ctrl+P` ואז למשל `Program.cs` או `FormTemplatesController`.
- עורך מלא עם תיקיות: `Ctrl+Shift+P` → **Open IDE**. זה פותח את הפרויקט המרוחק כמו VS Code: `backend/HrForms.Api/...`

מה שצריך לראות עכשיו:

```text
README.md
backend/HrForms.sln
backend/HrForms.Api/
  Controllers/FormTemplatesController.cs
  Services/...
  Store/...          ← המאגר בזיכרון
  Domain/...
```

הקבצים **לא** יופיעו בתיקייה מקומית במחשב העבודה. אם פתחת Cursor על תיקייה ריקה אצלך — זה מקום אחר. צריך את חלון הסוכן / Open IDE של השיחה הזו.

### איך רואים שהשרת רץ

בשיחה אמורה להיות כרטיסיית **Preview**. לחיצה עליה פותחת את Swagger.

ישירות: [http://127.0.0.1:43142/swagger](http://127.0.0.1:43142/swagger) — זה עובד מתוך סביבת Cursor (Preview / הדפדפן של הסוכן), לא מ-Chrome הרגיל במחשב העבודה, כי השרת רץ אצלי בענן.

### איך ממשיכים להתכתב משם

כותבים בתיבת ההודעה של **אותו** סוכן, כמו עכשיו. כל הודעה ממשיכה את העבודה על אותם קבצים.

לא לפתוח Chat/Agent חדש — ייווצר פרויקט ריק בלי הקוד.

### מה לא לעשות במחשב העבודה

לא צריך `winget`, לא צריך «לעקוף» הרשאות, לא צריך להעתיק קבצים למחשב. למבחן ממשיכים כאן: אני כותבת, את רואה ב-Changes / Open IDE / Preview, ועונות בשיחה.

אם תרצי מאגר GitHub משלך: בחלון הסוכן יש כפתור **Create repo**. עד אז הקוד כבר שמור בשיחה הזו.

כשתראי את `backend/HrForms.Api` — כתבי, ונעבור ל-Angular.

---

## הודעה 9 — משתמשת

לחצתי על הקישור 
http://127.0.0.1:43142/swagger
לא פתח סאוגר 
מצורפת שגיאה

## תשובה 9 — Cursor

השרת כנראה כבה, או שהדפדפן ניסה לפתוח את הכתובת אצלך במחשב במקום אצלי. בודק ומעלה אותו מחדש.

השרת אצלי **רץ תקין**. השגיאה היא כי `127.0.0.1` זה «המחשב שלי», לא המחשב בעבודה. כשלחצת על הקישור, הדפדפן חיפש את פורט 43142 אצלך — ושם אין שרת, לכן `refused to connect`.

אל תדביקי את הכתובת ב-Chrome / Edge / בדפדפן של Cursor אצלך.

**מה לעשות:** בשיחה עם הסוכן, לחצי על כרטיסיית **Preview** (לא על הטקסט `http://127.0.0.1...`). Preview פותח מנהרה מהענן למסך שלך. הכרטיס מופיע שוב למטה.

אם אין כרטיס Preview: חלון Agents → אותה שיחה (**מטלת רשות המיסים**) → חפשי Preview / Open Preview ליד ההודעה שבה הדלקתי את השרת.

ב-Swagger אחרי שנפתח: `POST /api/form-templates` → Try it out.

> כרטיסיית תצוגה מקדימה בסביבת Cursor «HR Forms API» — לחצי כאן על Preview — לא על כתובת 127.0.0.1 בדפדפן הרגיל. (כתובת פנימית: `http://127.0.0.1:43142/swagger` — נפתחת מ-Preview, לא מדפדפן המחשב בעבודה.)

---

## הודעה 10 — משתמשת

מצוין עובד, עכשיו אני צריכה שתסביר בפירוט את המשמעות של כל אוביקט ולמה בחרת להשתמש דווקא בצורה הזו

## תשובה 10 — Cursor

אעבור על האובייקטים בקוד כמו שהם עכשיו, ואסביר מה כל אחד מייצג ולמה נבחר כך — מול דרישות המבחן.

המבחן ביקש שלושה דברים במודל: **מעטפת טופס**, **מבנה דינמי של שדות**, **מסלול אישורים**. לכן אין «אובייקט אחד גדול עם HTML», אלא גרף: תבנית שמחזיקה שתי רשימות. זה אותו דבר כמו שלוש טבלאות עם קשרי 1:N — רק שכרגע זה בזיכרון.

```text
FormTemplate
 ├── Fields[]   → FormField
 └── Steps[]    → ApprovalStep
```

שמירה «בשלמותו» במבחן = אובייקט `FormTemplate` אחד שנכנס למאגר כבר עם השדות והשלבים בפנים. אין שמירה בשלוש קריאות נפרדות.

---

### 1. `FormTemplate` — תבנית הטופס (המעטפת)

```1:11:backend/HrForms.Api/Domain/FormTemplate.cs
public class FormTemplate
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public List<FormField> Fields { get; set; } = [];
    public List<ApprovalStep> Steps { get; set; } = [];
}
```

| שדה | משמעות במבחן | למה כך |
|-----|----------------|--------|
| `Id` | מזהה פנימי | השליפה `GET /{id}` דורשת מפתח. `int` פשוט, כמו identity ב-SQL Server. |
| `Name` | שם הטופס | חובה במסך («בקשת חופשה»). |
| `CreatedBy` | יוצר הטופס | המטלה ביקשה במפורש יוצר. אין התחברות, אז זה מחרוזת; אם ריק — `"מערכת"`. |
| `CreatedAt` | תאריך יצירה | גם זה במעטפת במטלה. `UtcNow` בשרת, לא מהלקוח — כדי שאי אפשר לזייף. |
| `Fields` | המבנה הדינמי | רשימת שדות, לא HTML. |
| `Steps` | מסלול האישורים | רשימת אבני דרך לפי סדר. |

למה תבנית ולא «טופס ממולא»: המערכת היא **בונה טפסים**. עובד עוד לא ממלא חופשה. שומרים הגדרה (template), לא מופע (instance). אם ישאלו בסרטון: בעתיד טבלה `FormSubmission` עם תשובות, בלי לשבור את התבנית.

למה לא מחרוזת HTML לטופס כולו: המטלה נתנה את זה כקיצור. דחינו כי אי אפשר לסנן שדות, אין טיפוסים, ו-XSS. מודל רלציוני מראה EF/יחסים — גם בלי DB אמיתי.

---

### 2. `FormField` — שדה דינמי בטופס

```1:10:backend/HrForms.Api/Domain/FormField.cs
public class FormField
{
    public int Id { get; set; }
    public int SortOrder { get; set; }
    public string Label { get; set; } = string.Empty;
    public FieldType FieldType { get; set; }
    public bool IsRequired { get; set; }
}
```

זה המימוש של «הוסף שדה טקסט / שדה תאריך». כל לחיצה ב-Angular תהיה עוד `FormField` ברשימה.

| שדה | משמעות | למה כך |
|-----|---------|--------|
| `Id` | מזהה השדה | אחרי מעבר ל-DB יהיה PK. בזיכרון — עקביות. |
| `SortOrder` | סדר התצוגה | בלי Drag & Drop הסדר = סדר ההוספה. נשמר במפורש כדי שאפשר יהיה לשנות סדר בלי לשנות Id. |
| `Label` | מה שהמשתמש רואה («תאריך התחלה») | לא שם טכני באנגלית. ב-HR התווית היא התוכן. |
| `FieldType` | טקסט או תאריך | רק מה שהמטלה ביקשה. enum, לא מחרוזת חופשית. |
| `IsRequired` | חובה בטופס | ולידציה עתידית כשעובד ממלא. בתבנית זה דגל הגדרה. |

אין `Value`: זה בונה תבניות, לא מילוי. אין `Placeholder` / `MaxLength`: לא נדרש, ובמבחן תוספות כאלה נראות כמו בזבוז זמן.

למה שורה לכל שדה ולא JSON אחד: אותו נימוק כמו טבלה `FormField` עם FK ל-`FormTemplate`. אפשר להוסיף סוג שדה בלי לשנות סכמה. Angular יעבוד עם `FormArray` — שורה בזיכרון = שורה בטופס.

---

### 3. `ApprovalStep` — אבן דרך במסלול

```1:10:backend/HrForms.Api/Domain/ApprovalStep.cs
public class ApprovalStep
{
    public int Id { get; set; }
    public int StepOrder { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ApproverIdentity { get; set; } = string.Empty;
    public ApprovalActionType ActionType { get; set; }
}
```

המטלה דרשה לכל שלב: **סדר, שם, זהות מאשר, סוג פעולה**. ארבעה שדות — לא פחות.

| שדה | משמעות | למה כך |
|-----|---------|--------|
| `StepOrder` | שלב 1, 2, 3… | מסלול הוא רצף. מנהל ישיר לפני HR. |
| `Name` | «אישור מנהל ישיר» | מה שמופיע במסך. |
| `ApproverIdentity` | מי המאשר | במערכת אמיתית זה FK לעובד. במבחן אין ניהול משתמשים, לכן מחרוזת (ת"ז / מספר עובד / שם). בסרטון: «זה placeholder לזהות; אחר כך טבלת Employees». |
| `ActionType` | מה מותר למאשר | לא כל שלב הוא «רק אשר». |

אין סטטוס `Pending/Approved`: זה הגדרת המסלול, לא ריצה של בקשה חיה.

---

### 4. שני ה-enum — למה לא מחרוזת

**`FieldType`:** `Text = 1`, `Date = 2`  
רק מה שהמטלה הדגימה. מתחילים מ-1 ולא מ-0 כדי ש-0 = «לא נשלח» ייכשל בולידציה.

**`ApprovalActionType`:**  
- `Approve` — רק אישור (למשל HR אחרי שהמנהל כבר החליט)  
- `Reject` — רק דחייה (נדיר, אבל חוקי)  
- `ApproveOrReject` — המקרה הרגיל למנהל

enum ולא `"approve"` חופשי: OOP, Swagger מציג רשימה סגורה, אי אפשר לשלוח `"asdf"`. ב-JSON זה `"Date"` / `"Approve"` בזכות `JsonStringEnumConverter` — קריא בסרטון.

להרחבה: `Number`, `TextArea` בשדות; `ReturnForCorrection` בשלבים — בלי לשבור את המודל, רק ערך חדש ב-enum.

---

### 5. למה שלושה אובייקטים ולא אחד

חלופה שנפסלה: מחלקה אחת עם `string Html` + `string WorkflowJson`.

| | גרף של שלוש מחלקות (מה שבחרנו) | HTML / JSON אחד |
|--|-------------------------------|------------------|
| התאמה למטלה | מעטפת / שדות / שלבים במפורש | הכל בתוך מחרוזת |
| OOP | כל מושג = מחלקה | מחרוזות |
| מעבר ל-SQLite | כל מחלקה = טבלה, `Fields`/`Steps` = 1:N | עמודה אחת |
| Angular | `FormArray` טבעי | textarea |
| שמירה בשלמותו | אובייקט אב עם ילדים ב-POST אחד | גם אפשרי, אבל בלי מבנה |

בזיכרון זה נראה כמו «רשימות בתוך אובייקט». ב-DB זה יהיה:

```text
FormTemplate 1──* FormField
FormTemplate 1──* ApprovalStep
```

אותן מחלקות. מחליפים רק את המאגר.

---

### 6. חוזים (DTO) — למה לא מחזירים את `FormTemplate` ישירות

שלושה סוגי מסרים, כי ל-API יש שלושה שימושים:

**נכנס — `CreateFormTemplateRequest`**  
מה שהלקוח שולח. בלי `Id` ובלי `CreatedAt`: את אלה השרת קובע. אחרת הלקוח יכול לדרוס מזהים.

**רשימה — `FormTemplateListItemDto`**  
`id, name, createdBy, createdAt, fieldCount, stepCount`. בלי כל השדות והשלבים. הרשימה קלה; מי שפותח טופס קורא `GET /{id}`.

**מלא — `FormTemplateDto` + `FormFieldDto` + `ApprovalStepDto`**  
העתק חיצוני של הגרף, אחרי שמירה/שליפה. מפריד את מודל הפנים ממודל ה-HTTP. אם נוסיף שדה פנימי (למשל `DeletedAt`) הוא לא ידלוף אוטומטית החוצה.

זו שכבת **Contracts**: צורת התקשורת. **Domain** הוא האמת העסקית.

---

### 7. שלוש השכבות — מי עושה מה

```text
Controller  →  רק HTTP (200, 201, 400, 404)
Service     →  חוקים: ולידציה, Trim, סדר, «מערכת»
Store       →  רק שמירה ושליפה. לא יודע מה זה טופס חוקי
```

**Controller** לא בונה אובייקטים ולא בודק שם ריק. אם הולידציה תישבר, זה ב-Service. אם נחליף זיכרון ב-SQLite, ה-Controller לא משתנה.

**Service** מרכיב את ה-`FormTemplate` השלם, נותן `SortOrder`/`StepOrder` לפי סדר הרשימה, וזורק `FormValidationException`. זו הלוגיקה שהמבחן רוצה בשכבת שרת.

**Store** הוא Singleton: רשימה אחת לכל חיי השרת. `Scoped` היה נותן מאגר חדש לכל בקשה והנתונים היו נעלמים בין POST ל-GET.

`lock` + `Clone`: שתי בקשות במקביל לא ישחיתו את הרשימה, והלקוח לא יקבל ייחוס לאותו אובייקט שבפנים (אחרת שינוי ב-DTO היה משנה את הזיכרון). ב-DB הנעילה מיותרת; בזיכרון היא חובה.

ממשקים `IFormTemplateStore` / `IFormTemplateService`: ביום שמוסיפים EF, מממשים `SqliteFormTemplateStore` בלי לגעת ב-Controller.

---

### 8. מה בכוונה אין

| לא קיים | סיבה |
|---------|------|
| משתמש / Login | לא במטלה |
| טבלת Employees | זהות מאשר כמחרוזת מספיקה ל-PoC |
| HTML של הטופס | נבחר מודל שדות |
| ערכי מילוי (`Submission`) | זה בונה תבניות |
| מחיקה/עדכון | המטלה ביקשה שמירה, רשימה, שליפה |

---

### משפט לסרטון

«פיצלתי לשלוש ישויות כמו שלוש טבלאות: תבנית, שדות, אבני דרך. התבנית נשמרת בשלמותה כי השדות והשלבים יושבים עליה. בחרתי אובייקטים ולא HTML כדי שהמבנה יהיה רלציוני, עם enum לסוגים, ועם שכבות Controller/Service/Store כדי שאפשר יהיה להחליף את הזיכרון במסד בלי לשכתב את ה-API.»

אם תרצי, בשלב הבא נעבור שורה-שורה על בקשת JSON ב-Swagger ונקשור כל שדה לאובייקט, או נתחיל את Angular.

---

## הודעה 11 — משתמשת

עכשיו נעבור לפירוט על השכבות ולמה בחרת לקרוא לכל שכבה בצורה כזו, בנוסף אני צריכה שהתגובות שלך יהיו מימין לשמאל כמו בערית ולא משמאל לימין כמו אנגלית

## תשובה 11 — Cursor

השכבות הן חלוקת אחריות, לא «עוד תיקיות». כל שם אומר **מה השכבה מותרת לעשות** — ומה אסור לה. לכן לא קראתי להן `Helpers`, `Logic` או `Utils`: שמות כאלה לא אומרים כלום במבחן.

כיוון הקריאה של ההסבר מימין לשמאל, כמו עברית. שמות בקוד נשארים באנגלית — זה התקן ב-.NET, וכך גם תסבירי בסרטון: «השמות באנגלית כי זו שפת המסגרת; האחריות בעברית».

---

### התמונה הכללית

ארבע שכבות תוכן, ועוד שכבת הרצה:

```text
Contracts     ← צורת התקשורת (JSON)
Controller    ← HTTP בלבד
Service       ← חוקים עסקיים
Store         ← שמירה ושליפה
Domain        ← מה זה טופס / שדה / שלב
Program.cs    ← הרכבה (מי מממש מה)
```

בקשה חיה זורמת מלמעלה למטה, תשובה חוזרת מלמטה למעלה:

```text
Swagger / Angular
    ↓  JSON
Controller
    ↓  CreateFormTemplateRequest
Service          (ולידציה, הרכבת אובייקט)
    ↓  FormTemplate
Store            (רשימה בזיכרון)
    ↓
Domain           (האובייקטים עצמם)
```

למה לא הכל בקונטרולר אחד: המבחן כתב במפורש «חלוקה נכונה לשכבות» ו-OOP. אם ה-POST בונה אובייקטים, בודק שם ריק ושם ברשימה — זו שכבה אחת שמעמיסה שלושה תפקידים, ואי אפשר להחליף זיכרון ב-SQLite בלי לגעת ב-HTTP.

---

### למה השמות האלה, ולא השמות האחרים

#### `Domain` — לא `Models` ולא `Entities`

**משמעות:** מושגי העסק. טופס, שדה, אבן דרך, סוגי שדה ופעולה.

**למה `Domain`:** בספרי .NET זה השם ל«עולם הבעיה», לא ל«איך שומרים». `Models` עמום (לפעמים מתכוונים ל-JSON). `Entities` רומז ל-EF / טבלאות. עדיין אין מסד — `Domain` נכון לשני המצבים: גם זיכרון, גם SQL אחר כך.

**אסור לשכבה:** לדעת שיש HTTP, לדעת שיש רשימה בזיכרון, לעשות `Trim` או ולידציה של בקשה.

---

#### `Contracts` — לא `Dto` ולא `ViewModels`

**משמעות:** החוזה מול החוץ. מה נכנס ב-POST, מה יוצא ב-GET רשימה, מה יוצא ב-GET לפי מזהה.

**למה `Contracts`:** זה לא «הטופס האמיתי». זה המסר ברשת. לכן יש `CreateFormTemplateRequest` בלי `Id` ו-`CreatedAt`, ויש `FormTemplateListItemDto` בלי כל השדות. `Dto` לבד הוא קיצור טכני; `ViewModels` שייך ל-UI. `Contracts` אומר: זו חתימת ה-API.

**למה שלושה חוזים ולא אחד:** רשימה לא צריכה 20 שדות. יצירה לא נותנת ללקוח לבחור מזהה. שליפה מלאה כן מחזירה את הגרף. כל חוזה = שימוש אחד.

---

#### `Controllers` — לא `Api` ולא `Presentation`

**משמעות:** דלת HTTP. מצב תשובה: 200, 201, 400, 404. לא יותר.

**למה `Controller`:** ב-ASP.NET זה השם הרשמי למחלקה עם `[ApiController]`. בוחן רואה `FormTemplatesController` ויודע מיד איפה ה-REST. `Presentation` מתאים ל-MVC עם HTML. `Api` כתיקייה מבלבל עם כל הפרויקט.

מה שיש בפנים במכוון:

- `GET` → `Ok`
- אין רשומה → `NotFound`
- שמירה הצליחה → `CreatedAtAction` (201 + קישור ל-`GET /{id}`)
- ולידציה נכשלה → `BadRequest` עם רשימת שגיאות

מה שאין במכוון: בניית `FormTemplate`, בדיקת שם ריק, גישה לרשימה. אם תוסיפי כלל «לפחות שני מאשרים» — זה לא כאן, זה ב-Service.

---

#### `Services` — לא `Bll` ולא `Logic`

**משמעות:** החוקים. מה נחשב טופס חוקי, איך מרכיבים אותו, מתי זורקים שגיאה.

**למה `Service`:** ב-.NET מודרני זה השם לשכבת שימוש (application service). `Bll` / `BusinessLogic` זה סגנון ישן של קורסים; עובד, אבל פחות מדויק. `Logic` לא אומר איזה לוגיקה.

כאן קורה:

- שם חובה, לפחות שדה, לפחות שלב
- `Trim` לטקסטים
- סדר (`SortOrder` / `StepOrder`) לפי מיקום ברשימה
- `CreatedAt` מהשעון של השרת
- המרה מ-Request ל-Domain ואז ל-Dto

**למה לא ב-Store:** המאגר לא אמור לדעת שטופס בלי שם פסול. הוא רק שומר. **למה לא ב-Controller:** כדי שאפשר יהיה לקרוא לאותם חוקים ממקום אחר (בדיקות, ג'וב) בלי HTTP.

`FormValidationException` יושבת ליד ה-Service כי זו שגיאת **כלל**, לא שגיאת רשת. הקונטרולר רק מתרגם אותה ל-400.

---

#### `Store` — לא `Repository` ולא `Dal`

**משמעות:** איפה הנתונים חיים עכשיו. רשימה בזיכרון, מזהים רצים, נעילה, העתק בהחזרה.

**למה `Store` ולא `Repository`:**  
`Repository` בדרך כלל אומר «מעטפת מעל טבלאות». עדיין אין טבלאות. `Store` אומר מאגר — בדיוק In-Memory. כשתהיה SQLite, אפשר מחלקה `SqliteFormTemplateStore` שמממשת **אותו** `IFormTemplateStore`, בלי לשנות Controller/Service.

**למה לא `Dal`:** Data Access Layer רומז ל-SQL / ADO. זה מבלבל כשאין DB.

למה Singleton: מופע אחד לכל חיי השרת. `Scoped` היה מאגר חדש לכל בקשה — POST שומר, GET מחזיר ריק.

למה ממשק `IFormTemplateStore`: כדי שה-Service תלוי בחוזה («יש Add / GetAll / GetById»), לא במימוש הזיכרון.

---

#### `Program.cs` — לא שכבת נתונים, שכבת הרכבה

כאן כתוב מי מממש מה:

- Store = Singleton של הזיכרון  
- Service = Scoped (מופע לכל בקשה)  
- JSON enum כמחרוזת  
- Swagger, CORS  

בלי זה השכבות לא מחוברות. זו לא לוגיקה עסקית — זו תשתית.

---

### למה פרויקט אחד עם תיקיות, לא ארבעה פרויקטים

`HrForms.Domain` / `Application` / `Infrastructure` / `Api` כ-csproj נפרדים זה Clean Architecture מלא. למבחן של שלוש שעות זה כבד: יותר קבצי פרויקט, יותר `using`, אותו רעיון.

תיקיות בתוך API אחד נותנות **אותה חלוקה מנטלית** שבוחן מחפש, בלי טקס. השמות נשארו כמו בארכיטקטורה הגדולה (`Domain`, `Service`, `Store`) כדי שאפשר יהיה להגיד בסרטון: «אלה אותן שכבות; ברגע שיש DB נוציא את ה-Store לפרויקט Infrastructure».

---

### איך להגיד את זה בסרטון (קצר)

«פיצלתי לארבע שכבות לפי אחריות. Domain זה מהו טופס. Contracts זה מה שנכנס ויוצא ב-HTTP. Controller רק סטטוסים. Service החוקים. Store המקום שבו הנתונים נשמרים. קראתי Store ולא Repository כי כרגע אין מסד, רק זיכרון — והממשק מאפשר להחליף בלי לגעת בשאר.»

---

אם תרצי, השלב הבא: אותו הסבר על הזרימה של POST אחד מ-Swagger עד הרשימה בזיכרון, שלב-שלב. או מעבר ל-Angular.

---

## הודעה 12 — משתמשת

מצוין בוא נעבור לכתיבה יפה ונכונה של אנגולר, הפרויקט יהיה כתוב באנגולר 20 תוך שימוש במבנה הנכון והתקני של אנגולר מתקדם, וכן שימוש בסינטקס החדש של אנגולר ולא בקוד ישן
כמובן שמכאן להבא התגובות יהיו מימין לשמאל כמו עברית

## תשובה 12 — Cursor

נתחיל ב-Angular 20 עם מבנה תקני וסינטקס חדש בלבד: standalone, signals, `@if`/`@for`, ו-Reactive Forms. קודם יוצרים את הפרויקט, אחר כך מחברים למסך יצירת הטופס.

המסך רץ. לחצי על **Preview** למטה (לא על כתובת בדפדפן של המחשב בעבודה) — אותו כלל כמו ב-Swagger.

נבנה Angular **20**, standalone, בלי `NgModule`, בלי `*ngIf` / `*ngFor`, בלי constructor injection.

### מבנה תקני

```text
frontend/src/app/
  core/           תשתית לכל האפליקציה
    models/       טיפוסים כמו ב-API
    api/          HttpClient בלבד
    state/        signals — מצב מול השרת
    interceptors/ שגיאות HTTP אחידות
  features/
    form-builder/ המסך היחיד במבחן
      form-builder.ts      הדף: FormGroup
      field-editor.ts      FormArray של שדות
      milestone-editor.ts  FormArray של אבני דרך
      template-list.ts     רשימה לקריאה בלבד
```

`core` לא מכיר תבניות HTML. `features` לא יודע איך בנוי השרת — רק את ה-API. זה הפיצול הסטנדרטי באנגולר מודרני, במקביל ל-Controller / Service / Store בשרת.

### סינטקס חדש — מה יש ומה אין

| יש (Angular 20) | אין (קוד ישן) |
|-----------------|---------------|
| `inject()` | `constructor(private http: ...)` |
| `input()` / `output()` | `@Input()` / `@Output()` |
| `@if` / `@for` / `@else` | `*ngIf` / `*ngFor` |
| `signal()` למצב | BehaviorSubject לכל באנר |
| `ChangeDetectionStrategy.OnPush` + zoneless | Zone.js |
| `loadComponent` בנתיב | מודול עם `declarations` |
| `NonNullableFormBuilder` + טפסים מטיפוסים | `FormGroup` בלי טיפוס |
| interceptor כפונקציה | מחלקה `HttpInterceptor` |

Reactive Forms נשארו במכוון: המבחן דרש אותם. `FormArray` לכל שדה ולכל אבן דרך — זו בדיוק הוספה בלחיצה בלי Drag & Drop.

המצב (טעינה, שגיאה, הצלחה, רשימה, טופס נבחר) ב-`FormTemplatesState` עם signals. לא NgRx: מסך אחד, שירות אחד.

### מה לעשות במסך

1. שם טופס, למשל «בקשת חופשה»  
2. הוסף שדה טקסט / שדה תאריך  
3. הוסף אבן דרך (שם, זהות מאשר, סוג פעולה)  
4. שמור טופס בשלמותו  
5. בצד שמאל (ויזואלית; ב-RTL זה תחילת העמוד השני) — הרשימה מתעדכנת, לחיצה שולפת לפי מזהה  

שמירה בלי שם/שדות/שלבים תיחסם בצד הלקוח, ואם עוברים את זה — גם בשרת.

> כרטיסיית תצוגה מקדימה בסביבת Cursor «יצירת טופס חדש» — Angular 20: שם, שדות דינמיים, אבני דרך, שמירה לרשימה. (כתובת פנימית: `http://127.0.0.1:43143` — נפתחת מ-Preview, לא מדפדפן המחשב בעבודה.)

בדיקת המסך הסתיימה בהצלחה: יצירת טופס, שדות, אבן דרך, שמירה והצגה מהרשימה עבדו מקצה לקצה.

---

## הודעה 13 — משתמשת

מצוין עכשיו דבר ראשון תעלה את הפרויקט לגיט שלי, ואחכ נעבור על הקבצים שיצרת ותסביר בפירוט על כל קובץ ועל מבנה האנגולר ולמה, תוך הבנה שהשתמשנו באנגולר נכון ומתקדם

## תשובה 13 — Cursor

קודם נוודא שהכול ב-Git ומה אפשר לחבר לחשבון שלך, ואז נעבור קובץ-קובץ על מבנה Angular 20.

הקוד כבר ב-Git: שלושה קומיטים על `main` נדחפו מהסשן הזה (שרת, אנגולר, README). זה המאגר של הפרויקט בענן.

להגשה במבחן צריך קישור **GitHub / GitLab שלך**. בחלון הסוכן לחצי על **Create repo**. אחרי שנוצר מאגר על שמך — שלחי לי את הקישור, ואני אוודא שהקוד שם. בלי זה אין לי לאן לדחוף בחשבון GitHub, כי המחשב בעבודה חסום ואין כאן חיבור לחשבון GitHub שלך.

---

### למה המבנה הזה באנגולר 20

באנגולר ישן היה `AppModule`, `declarations`, קומפוננטות עם `@Input` ו-`*ngFor`. כאן אין מודולים בכלל.

שלושה עקרונות:

1. **`core`** — קוד שרץ פעם אחת לכל האפליקציה: HTTP, מצב, טיפוסים.  
2. **`features`** — מסך עסקי. במבחן יש רק אחד: יצירת טופס.  
3. **קומפוננטה חכמה מול טיפשות** — הדף מחזיק את `FormGroup` ואת השמירה. הילדים רק מציגים `FormArray` ומדווחים על לחיצות.

זה מקביל לשרת: `api` כמו Controller של HTTP, `state` כמו Service, `models` כמו Domain.

```text
frontend/src/
  main.ts                 הדלקה
  index.html              RTL
  styles.scss             עיצוב גלובלי
  app/
    app.ts / html / scss  מעטפת
    app.config.ts         ספקים
    app.routes.ts         נתיבים
    core/
    features/form-builder/
```

---

### קבצי ההפעלה

**`main.ts`**  
`bootstrapApplication(App, appConfig)` — בלי `platformBrowserDynamic` ובלי `AppModule`. זו נקודת הכניסה של אנגולר מודרני.

**`index.html`**  
`lang="he"` ו-`dir="rtl"` ברמת המסמך, לא ב-CSS בלבד. כל המסך נקרא מימין לשמאל.

**`app.config.ts`**  
כאן מחברים את התשתית, לא בקומפוננטה:

- `provideZonelessChangeDetection()` — בלי Zone.js. עדכונים מגיעים מ-signals ומאירועי משתמש.  
- `provideHttpClient(withFetch(), withInterceptors(...))` — `fetch` במקום XHR, interceptor כפונקציה.  
- `provideRouter(routes)`  

אין `HttpClientModule`. זה ה-API החדש.

**`app.routes.ts`**  
המסך נטען ב-`loadComponent` — lazy load בלי `loadChildren` למודול. גם אם יש מסך אחד, זה הדפוס הנכון להרחבה.

**`app.ts`**  
רק `RouterOutlet`. `OnPush`. `imports: [RouterOutlet]` במקום `declarations`. המחלקה נקראת `App` ולא `AppComponent` — כך ה-CLI של אנגולר 20 מייצר.

**`proxy.conf.json`**  
הדפדפן קורא ל-`/api/...`. Angular מעביר לשרת ב-43142. בלי זה Preview היה נתקע על `127.0.0.1` אצלך במחשב.

---

### `core` — התשתית

**`core/models/form-template.model.ts`**  
חוזה TypeScript זהה ל-JSON של ה-API: `FieldType`, `ApprovalActionType`, בקשת יצירה, רשימה, פירוט. תוויות בעברית ל-enum. בלי זה הטופס והשרת מתפצלים בשמות שדות.

**`core/api/form-templates.api.ts`**  
שלוש קריאות בלבד: `list`, `getById`, `create`. `inject(HttpClient)`, בלי constructor. **לא** מחזיק signals ולא מציג שגיאה. אחריות אחת: רשת.

**`core/interceptors/api-error.interceptor.ts`**  
`HttpInterceptorFn` — פונקציה, לא מחלקה עם `intercept()`. ממיר 400 עם `errors[]` לאובייקט אחיד. ה-state לא צריך לפענח `HttpErrorResponse` בכל מקום.

**`core/state/form-templates.state.ts`**  
כאן ניהול ה-state שהמבחן ביקש — **signals**, לא NgRx (מוגזם למסך אחד) ולא משתנים רגילים בקומפוננטה:

- `templates` — הרשימה  
- `selected` — GET לפי מזהה  
- `loadingList` / `loadingDetails` / `saving`  
- `error` / `success`  

`providedIn: 'root'` — מופע יחיד. הקומפוננטות קוראות `state.templates()` בתבנית, ואנגולר מרנדר כי זה signal.

---

### `features/form-builder` — המסך

**`form-builder.types.ts`**  
טפסים **מטיפוסים** (Typed Reactive Forms). כל ביקורת `form.controls.fields` יודעת שיש `label` ו-`fieldType`. בלי זה חוזרים ל-`get('name')` כמו באנגולר 8.

**`form-builder.ts`** — הקומפוננטה החכמה  

- `inject(NonNullableFormBuilder)` — אין `null` בערכים.  
- `FormArray` לשדות ולשלבים: לחיצה = `push`, הסרה = `removeAt`.  
- `OnPush`  
- `imports` של הילדים במקום מודול.  
- `save()` בודק `invalid`, ממלא `touched`, שולח ל-state, מאפס אחרי הצלחה.

זה החיבור למבחן: Reactive Forms + רשימה דינמית בזיכרון, בלי Drag & Drop.

**`form-builder.html`**  
`@if (state.error(); as message)` — control flow חדש, לא `*ngIf`.  
`[fields]="form.controls.fields"` — מעבירים את ה-FormArray לילד.  
`(addText)="addField('Text')"` — הילד לא יודע לבנות Group, רק מודיע.

**`field-editor.ts` / `milestone-editor.ts`**  
קומפוננטות מצגות:

- `input.required<FormArray<...>>()` במקום `@Input()`  
- `output<void>()` במקום `@Output() EventEmitter`  
- אין HTTP, אין שמירה  

**`field-editor.html`**  
`@for (field of fields().controls; track $index)` — לא `*ngFor`.  
`[formGroup]="field"` על כל שורה — כל שדה הוא `FormGroup` בתוך המערך.

**`template-list.ts`**  
רק קלט: רשימה, נבחר, טעינה. פלט: `selectId`.  
`DatePipe` ב-`imports` של הקומפוננטה, לא ב-`AppModule`.  
`@for (item of templates(); track item.id)` — מעקב לפי מזהה יציב, לא אינדקס.

---

### משפט לסרטון

«האפליקציה היא Angular 20 standalone, בלי מודולים. פיצלתי ל-core ו-feature. HTTP בשירות נפרד, מצב ב-signals, הטופס ב-Reactive Forms מטיפוסים עם FormArray. הילדים מקבלים input/output החדשים, והתבניות ב-@if/@for. זו הדרך התקנית היום, לא הסגנון של Angular 11.»

כשתלחצי Create repo ותשלחי קישור — נחבר את ההגשה. אם תרצי, נעבור אחר כך על קבצי השרת באותה רמת פירוט.

המאגר שלך נוצר. בודק שהקוד כבר שם, ואז אשלח את פרטי הגישה והשכפול.

המאגר שלך מוכן: **misim-dev-kit**, פרטי.

לצפייה בדפדפן: [https://cursor.com/codebase/tamar-rein-birenbaum/misim-dev-kit](https://cursor.com/codebase/tamar-rein-birenbaum/misim-dev-kit)

הנראות **Private**. אפשר לשנות בהגדרות באותו עמוד.

המחשב שלך Windows. Origin CLI רץ ב-**WSL** בלבד, לא ב-PowerShell. להעתיק למחשב, פתחי WSL והדביקי:

```bash
# Run in WSL (Origin CLI is not available in PowerShell)
# Install the Origin CLI
curl -fsSL https://downloads.cursor.com/origin/install.sh | sh

# Sign in (also sets up git credentials)
origin auth login

# Clone the repository
origin repo clone tamar-rein-birenbaum/misim-dev-kit
```

אם אחרי ההתקנה כתוב ש-`origin` לא נמצא, הוסיפי את התיקייה ל-PATH ב-WSL (bash):

```bash
echo 'export PATH="$HOME/.local/bin:$PATH"' >> ~/.bashrc
source ~/.bashrc
```

תיעוד Origin CLI: [https://cursor.com/docs/origin/cli](https://cursor.com/docs/origin/cli)

במחשב העבודה אין צורך בזה כדי להמשיך: הקוד רץ כאן, וההגשה יכולה להיות הקישור למאגר. כשתרצי, נמשיך בפירוט קבצי השרת או בהכנה לסרטון.

---

## הודעה 14 — משתמשת

אני צריכה שהפרויקט יהיה ב  GITHUB ויש לך חיבור לגיט שלי, תדחוף לשם את הקוד

## תשובה 14 — Cursor

בודק איך מחוברים GitHub ו-Origin, ואז דוחף את הקוד למאגר שלך.

בדקתי את החיבורים בסשן הזה. **אין כאן התחברות ל-GitHub.** `gh` לא מחובר, ואין `GITHUB_TOKEN`. לכן אי אפשר לדחוף עכשיו ל-github.com.

מה שמחובר הוא Git של Cursor (Origin): המאגר **misim-dev-kit**, פרטי.  
לצפייה: [https://cursor.com/codebase/tamar-rein-birenbaum/misim-dev-kit](https://cursor.com/codebase/tamar-rein-birenbaum/misim-dev-kit)

המבחן מבקש קישור ל-GitHub / GitLab / Bitbucket. Origin לבד לא מחליף את זה.

כדי שאשלח ל-GitHub צריך אחד מאלה:

1. ב-Cursor: Settings → חיבור GitHub (Connect GitHub), ואז לכתוב לי כאן «מחובר» — אצור מאגר ואדחוף.  
2. או ליצור מאגר ריק ב-github.com (למשל `misim-dev-kit`) ולשלוח לי את הכתובת  
   `https://github.com/<המשתמש-שלך>/misim-dev-kit`  
   יחד עם הרשאה לדחיפה (PAT עם הרשאת `repo`, או התחברות GitHub ב-Cursor).

בלי התחברות GitHub אני לא יכולה לדחוף לשם, גם אם הקוד כבר שמור ב-misim-dev-kit.

---

## הודעה 15 — משתמשת

תסביר לי איך לחבר אותך ל GITHUB שלי שתוכלי לדחוף את הקוד לשם

## תשובה 15 — Cursor

אבדוק בתיעוד הנוכחי של Cursor איך מחברים GitHub לסוכן ענן, כדי לתת לך צעדים מדויקים.

החיבור הוא **בחשבון Cursor שלך**, לא בקוד. אחרי שהוא מחובר, סוכן ענן יכול לדחוף ל-GitHub. בסשן הנוכחי עדיין אין התחברות — לכן הצעדים האלה אצלך.

### 1. חיבור GitHub ל-Cursor

1. היכנסי ל-[Integrations בלוח הבקרה](https://cursor.com/dashboard?tab=integrations) עם אותו חשבון Cursor שרץ כאן.  
2. ליד **GitHub** לחצי **Connect** (או **Manage Connections** אם כבר היה ניסיון).  
3. GitHub יבקש להתקין את האפליקציה **Cursor**. אפשר גם ישירות מ-[github.com/apps/cursor](https://github.com/apps/cursor).  
4. בחרי **All repositories**, או **Selected repositories** ואז סמני את המאגר שאליו נדחוף.  
5. אשראי הרשאות. חשוב שיהיה **כתיבה** למאגר (clone + push), לא קריאה בלבד.  
6. חזרי לדשבורד. ליד GitHub אמור להופיע מחובר.

בלי הצעד הזה אין לי `gh` ואין אסימון — אי אפשר לדחוף.

### 2. מאגר ריק ב-GitHub (אם עוד אין)

1. [github.com/new](https://github.com/new)  
2. שם, למשל `misim-dev-kit`  
3. **Private** או Public — לבחירתך  
4. **בלי** README / .gitignore / license (מאגר ריק, כדי שהדחיפה הראשונה תהיה פשוטה)  
5. Create repository

העתיקי את הכתובת, למשל:  
`https://github.com/<שם-המשתמש-שלך>/misim-dev-kit`

### 3. חזרה אליי

בשיחה הזו כתבי:

- «GitHub מחובר»  
- ואת קישור המאגר  

אז אנסה לדחוף את `main` לשם.

אם הסשן הזה עדיין בלי הרשאה (זה קורה כשהסוכן התחיל לפני החיבור): פתחי **סוכן ענן חדש** על המאגר ב-GitHub, וכתבי שם «דחפי את הקוד של מטלת הטפסים ל-main». סוכן שנולד על מאגר GitHub כבר מחובר אליו.

### מה לא צריך

לא PAT בצ'אט, לא `gh auth login` במחשב העבודה, לא Origin CLI בשביל הצעד הזה. החיבור הוא Cursor ↔ אפליקציית GitHub.

כשהחיבור מוכן — שלחי את הקישור ונמשיך בדחיפה.

---

## הודעה 16 — משתמשת

נראה שמחובר מצוי
מצרפת קישור למאגר החדש https://github.com/tamarbir/misim-dev-kit

## תשובה 16 — Cursor

GitHub מחובר כ-`tamarbir`. בודק גישה למאגר ודוחף אליו את הקוד.

החיבור בדשבורד תקין: GitHub מחובר כ-**tamarbir**, והמאגר [github.com/tamarbir/misim-dev-kit](https://github.com/tamarbir/misim-dev-kit) קיים (כרגע **Public**).

מה שחסר הוא הרשאת **דחיפה בתוך הסשן הזה**. הסוכן נפתח כפרויקט ב-Cursor Git, לא מתוך המאגר ב-GitHub. חיבור Integrations מאפשר לפתוח סוכן **חדש** על מאגר GitHub — הוא לא מזריק אסימון אחורה לשיחה שכבר רצה. בדקתי: `gh` לא מחובר, ודחיפה ל-github.com נחסמת.

לכן אני לא יכולה לדחוף מכאן, גם אחרי שהחיבור בדשבורד ירוק.

### איך כן להעלות ל-GitHub (עם Git שכבר הותקן אצלך)

ב-WSL (לא PowerShell):

```bash
# אם origin לא מותקן:
curl -fsSL https://downloads.cursor.com/origin/install.sh | sh
echo 'export PATH="$HOME/.local/bin:$PATH"' >> ~/.bashrc
source ~/.bashrc

origin auth login
origin repo clone tamar-rein-birenbaum/misim-dev-kit
cd misim-dev-kit
git remote add github https://github.com/tamarbir/misim-dev-kit.git
git push -u github main
```

ב-`git push` ייפתח דפדפן להתחברות GitHub (`tamarbir`). בלי הרשאת מנהל.

תיעוד Origin: [https://cursor.com/docs/origin/cli](https://cursor.com/docs/origin/cli)

### אם תרצי שאני אדחוף בעצמי

פתחי **סוכן ענן חדש**, ובבחירת המאגר בחרי מ-GitHub את `tamarbir/misim-dev-kit` (לא פרויקט חדש ריק).  
בהודעה הראשונה כתבי שתייבא את הקוד מהשיחה [מטלת רשות המיסים](https://cursor.com/agents/bc-328aa3a6-ca5a-4b8a-8f82-e9e54f060d7c) ותדחוף ל-`main`.

סוכן שנולד על מאגר GitHub מקבל הרשאות דחיפה. הסוכן הזה — לא.

אחרי שהקוד ב-GitHub, שלחי שוב את הקישור ונוודא שהקבצים שם. אם המאגר צריך להיות פרטי להגשה — Settings ב-GitHub → Change visibility.

---

## הודעה 17 — משתמשת

איך פותחים סוכן ענן חדש ?

## תשובה 17 — Cursor

בודק את הצעדים העדכניים ב-Cursor לפתיחת סוכן ענן חדש, עם בחירת מאגר GitHub.

הכי פשוט מהדפדפן — בלי להתקין כלום במחשב העבודה.

### מהדפדפן

1. היכנסי ל-[cursor.com/agents](https://cursor.com/agents) עם אותו חשבון.  
2. לחצי **New Agent** / **סוכן חדש** (כפתור בראש הרשימה).  
3. **חשוב:** בבחירת המאגר בחרי מ-**GitHub** את `tamarbir/misim-dev-kit`.  
   לא «New project», ולא את השיחה הנוכחית «מטלת רשות המיסים».  
4. בתיבת ההודעה הדביקי את הטקסט למטה ושלחי.

אם מופיע תפריט Local / Cloud — בחרי **Cloud**.

### מאפליקציית Cursor במחשב

1. `Ctrl+Shift+P` → **Open Agents Window**.  
2. **New Agent**.  
3. מתחת לתיבת ההודעה, בתפריט, בחרי **Cloud**.  
4. בחרי מאגר **GitHub** → `tamarbir/misim-dev-kit`.  
5. אותה הודעה, שליחה.

### מה להדביק בסוכן החדש

```text
המאגר ב-GitHub ריק. תעתיקי אליו את הקוד המלא של מטלת בניית הטפסים
(Angular 20 + .NET 8) מהסוכן הזה:
https://cursor.com/agents/bc-328aa3a6-ca5a-4b8a-8f82-e9e54f060d7c
ותדחפי ל-main ב-https://github.com/tamarbir/misim-dev-kit
```

הסוכן החדש ירוץ בשיחה **אחרת**. את ממשיכה שם, לא כאן.

איך יודעים שהבחירה נכונה: בראש הסוכן כתוב `tamarbir/misim-dev-kit` מ-GitHub, לא פרויקט Origin חדש.

---

## הודעה 18 — משתמשת

בנתיים נעבור להכנה איך להציג את הסרטון בצורה נכונה מקצועית ומשכנעת

## תשובה 18 — Cursor

הסרטון הוא חלק מהציון: לא עיצוב, אלא **הסבר והגנה על בחירות**. מדברים רגוע, מראים מסך, לא קוראים מהדף כמו שיעור. אורך מומלץ: **6–9 דקות**. יותר מזה מאבדים אותם.

לפני ההקלטה: Swagger ו-Angular רצים ב-Preview. תרגול פעם אחת בלי הקלטה. לסגור התראות. חלון אחד מספיק — מסך יצירת הטופס, ובסוף אפשר לקפוץ לקבצים ב-IDE.

---

### מבנה הסרטון (תסריט)

#### 0:00–0:20 | פתיחה
«שלום, אני תמר. זו מטלת PoC לבניית טפסים ואבני דרך למחלקת הון אנושי. בסרטון: הדגמה חיה, הטכנולוגיות, מודל הנתונים, ואז שלוש שאלות הארכיטקטורה.»

לא להתנצל על עיצוב. המטלה אמרה שפונקציונליות חשובה יותר.

#### 0:20–2:30 | הדגמה (הלב)
לעבור **לאט**, עם משפט על כל פעולה:

1. «זה מסך יצירת טופס — מה שנדרש בחלק 2.»  
2. שם: בקשת חופשה. יוצר: תמר.  
3. «בונה שדות בלחיצה, בלי Drag & Drop — כמו במטלה. שדה טקסט ושדה תאריך.»  
4. «מסלול אישורים דינמי: שם שלב, זהות מאשר, סוג פעולה.»  
5. שמירה. «POST אחד שומר את הטופס בשלמותו: מעטפת + שדות + שלבים.»  
6. הרשימה מתעדכנת. לחיצה על הטופס. «זה GET רשימה ו-GET לפי מזהה.»  
7. ניסיון שמירה ריקה (בלי שם) — להראות ולידציה. זה נראה מקצועי.

אם משהו נכשל: לא למחוק הקלטה. להגיד «ולידציה בצד לקוח/שרת» ולתקן פעם אחת.

#### 2:30–4:00 | טכנולוגיות
לפתוח בקצרה `app.config.ts` או `Program.cs` — לא לגלול 200 שורות.

«צד לקוח: Angular 20, standalone, בלי NgModule. Reactive Forms עם FormArray לשדות ולשלבים — זה מה שהמבחן ביקש. מצב ב-signals, לא NgRx, כי יש מסך אחד. תבניות ב-@if/@for. Zoneless.»

«צד שרת: ASP.NET Core 8 Web API. שלוש שכבות: Controller רק HTTP, Service חוקים, Store שמירה. OOP: כל מושג עסקי הוא מחלקה, enum לסוג שדה ולסוג פעולה.»

«שמירה: In-Memory, כמו שהמבחן המליץ כדי לחסוך התקנות. המודלים והקשרים כאילו SQL Server.»

#### 4:00–5:30 | «מסד הנתונים» — גם בלי קובץ DB
כאן בודקים אם הבנת רלציוני. לדבר כאילו יש שלוש טבלאות:

```text
FormTemplate  1──*  FormField
      │
      └──*  ApprovalStep
```

«מעטפת: שם, תאריך יצירה, יוצר.  
שדות: סדר, תווית, סוג, חובה — זו הבחירה במקום HTML גולמי.  
אבני דרך: סדר, שם, זהות מאשר, סוג פעולה — בדיוק מה שביקשתם.»

למה לא HTML: «אי אפשר לשאול עליו, אין טיפוסים, וסיכון XSS. מודל שורות מאפשר מדד/שדה חדש בלי לשנות סכמה.»

למה לא טבלת Users: «PoC; זהות מאשר כמחרוזת. במערכת אמיתית FK לעובד.»

שמירה בשלמותו: «טרנזקציה לוגית אחת — האובייקט נכנס למאגר כבר עם הילדים. ב-SQL זו טרנזקציה על שלוש הטבלאות.»

#### 5:30–8:00 | חלק 3 — בעל פה

**שאלה 1 — ענן + On-Prem**  
«Angular מאחורי Front Door/WAF, חשוף לאינטרנט. ה-API ו-SQL ברשת פרטית (VNet). נתונים רגישים נשארים בארגון. חיבור ב-VPN או ExpressRoute. לא פותחים SQL לאינטרנט. זהות: Entra ID. סודות ב-Key Vault.»

**שאלה 2 — GenAI לטופס**  
«הצ'אט ב-Angular. הקריאה למודל **רק דרך ה-API** — מפתח לא בדפדפן. ה-AI מחזיר JSON של שדות לפי סכמה שלנו, לא HTML חופשי. State: מזהה שיחה + טיוטת הטופס בשרת. לפני תצוגה: ולידציית סכמה, allowlist של Text/Date. אם HTML — DOMPurify ו-CSP, בלי script.»

**שאלה 3 — אינטגרציה למערכת הישנה**  
«המערכת החדשה בענן מפרסמת תבנית מוכנה. לא כותבים ישר ל-DB של SHAAM. תור (Service Bus) או API גרסאי מאחורי gateway, מזהה יציב, idempotency. On-Prem צורך את האירוע ומעדכן את המערכת הקיימת.»

#### 8:00–8:30 | AI + סיום
«נעזרתי ב-Cursor (Grok). האחריות על הפתרון וההסבר שלי. היסטוריית השיחה תצורף להגשה.»

«זה PoC: בלי התחברות ובלי מילוי טופס אמיתי. ההרחבה הטבעית: טבלת עובדים, SQLite/SQL Server במקום הזיכרון, ומסכי ניהול לרשימה.»

---

### מה לא לעשות

- לא לקרוא README במלואו.  
- לא להגיד «לא הספקתי DB» — להגיד «In-Memory במכוון, מודל רלציוני».  
- לא «ה-AI כתב הכל».  
- לא Drag & Drop שלא בנינו.  
- לא להבטיח GitHub אם הדחיפה עוד לא הסתיימה — «הקוד ב-Git; הקישור בהגשה».

### צ'קליסט לפני Rec

- [ ] תרגול ההדגמה פעם אחת  
- [ ] שמירה מצליחה + ולידציה נכשלת  
- [ ] שלושת משפטי חלק 3 בעל פה, בלי נייר מול המצלמה (כן ליד המסך)  
- [ ] לציין Cursor  
- [ ] שמירת הקובץ: `תמר-ביירנבאום-מטלת-טפסים.mp4`

אם תרצי, בשלב הבא נעשה «חזרה» קצרה: אני שואלת כמו בוחנת, את עונה במשפט–שניים.

---

## הודעה 19 — משתמשת

מצוין בוא נעשה את זה

## תשובה 19 — Cursor

מתחילים. אני הבוחנת, את המועמדת. תעני במשפט–שניים, כמו בסרטון — בלי הרצאה.

---

**שאלה 1**

למה בחרת לשמור שדות כאובייקטים נפרדים, ולא כ-HTML של הטופס כולו? מה היתרון במבחן הזה?

---

## הודעה 20 — משתמשת

תוציא לי היסטורית התכתבות בשיחה הזו

## תשובה 20 — Cursor

מוציאה את היסטוריית השיחה כמסמך להגשה. קודם אשלוף את התמליל המלא של הסשן.

---

המסמך מסתיים בבקשה האחרונה לייצוא היסטוריית ההתכתבות. קובץ זה הוא הייצוא להגשה.

</div>
