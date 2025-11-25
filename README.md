# לבון

<img src="https://github.com/Games-Development-Course/Levon-game/blob/main/screenShots/logo.png" alt="drawing" width="50"/>

**לבון** הוא משחק עדין וחווייתי המלמד ילדים לזהות רגשות ולהגיב בצורה אמפתית. המשחק מבוסס על אינטראקציה עם דמויות שונות, הקשבה למצבן הרגשי ובחירה כיצד להתייחס אליהן.

[click here to play on itch.io](https://gamedevteamx.itch.io/levonmainloop)
## מאפיינים מרכזיים

* מתאים לילדים, במיוחד לילדים על הרצף האוטיסטי
* ללא "תשובה נכונה" אחת, אלא מקום לגילוי אישי והבנה
* מגוון אפשרויות תגובה: הקשבה, הצעה לשחק, נחמה, זמן לבד ועוד
* חוויית משחק רגועה, בטוחה ומונחית


<img src="https://github.com/Games-Development-Course/Levon-game/blob/main/screenShots/levon.png" alt="drawing" width="200"/>


## מטרת המשחק

לעזור לשחקנים לזהות רגשות אצל אחרים, להבין הקשרים חברתיים, וללמוד להגיב ברגישות ובחמלה.

## אופן המשחק

1. בכל שלב מוצגת דמות במצב רגשי כלשהו.
2. השחקן יכול לשאול את הדמות "מה קרה?" או לבחור פעולה.
3. כל בחירה מובילה לתגובה ייחודית, ולעיתים להמשך סיפור חדש.

## פלטפורמות

מובייל / טאבלט

## קהל יעד

ילדים בגילאי 4-9, הורים, מורים ומטפלים.

## סטטוס

בפיתוח ראשוני.

### שמות חברי הצוות:
מדמח - שגית מלכה, אביב נאמן ואביב תורג'מן.
ריפוי בעיסוק - שירה נכטנשטרן, רותם לוי ואוראל דן.

### UML
```mermaid
classDiagram
    class QuizStep {
        +Sprite image
        +string[] answers
        +int correctIndex
    }

    class UIController {
        +Image questionImage
        +Button[] answerButtons
        +TextMeshProUGUI tryAgainText
        +event Action<int> OnAnswerSelected()
        +DisplayStep(QuizStep)
        +ShowTryAgain(float)
        +SetInteractableButtons(bool)
    }

    class QuizManager {
        +QuizStep[] steps
        +int maxErrors
        -int currentStep
        -int errors
        +UIController uiController
        +SceneService sceneService
        +Start()
        +LoadStep(int)
        +HandleAnswer(int)
    }

    class ISceneService {
        <<interface>>
        +LoadScene(string)
    }

    class SceneService {
        +LoadScene(string)
    }

    class ButtonSoundPlayer {
        +AudioClip clickClip
        +PlayClick()
    }

    QuizManager --> UIController : uses
    UIController --> QuizStep : displays
    QuizManager --> SceneService : uses
    SceneService ..|> ISceneService
    ButtonSoundPlayer ..> Button
