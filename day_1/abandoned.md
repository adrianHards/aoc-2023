```csharp
int windowSize = 5;
bool breakFirstLoop = false;
for (int i = 0; i <= uncalibrated.Length - windowSize && !breakFirstLoop; i++)
{
    string window = uncalibrated.Substring(i, windowSize);
    foreach (var kvp in numberWords) {
        string wordToFind = kvp.Key;
        int replacementValue = kvp.Value;

        if (window.Contains(wordToFind))
        {
            uncalibrated = uncalibrated.Replace(wordToFind, replacementValue.ToString());
            breakFirstLoop = true;
            break;
        }
        if (breakFirstLoop) break;
    }
}

bool breakSecondLoop = false;
for (int i = uncalibrated.Length - windowSize; i >= 0 && !breakSecondLoop; i--)
{
    string window = uncalibrated.Substring(i, windowSize);
    foreach (var kvp in numberWords) {
        string wordToFind = kvp.Key;
        int replacementValue = kvp.Value;

        if (window.Contains(wordToFind))
        {
            uncalibrated = uncalibrated.Replace(wordToFind, replacementValue.ToString());
            breakSecondLoop = true;
            break;
        }
        if (breakSecondLoop) break;
    }
}
```
