# README.md

<div align="center">

# 🔍 Binary Search in C#

### پیاده‌سازی الگوریتم جستجوی دودویی

![C#](https://img.shields.io/badge/C%23-12.0-512BD4?style=for-the-badge&logo=csharp&logoColor=white)
![Complexity](https://img.shields.io/badge/Time-O(log%20n)-success?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Completed-success?style=for-the-badge)

</div>

---

## 🎯 باینری سرچ چیه؟

یه الگوریتم جستجوئه که توی یه **آرایه‌ی مرتب**، دنبال یه مقدار می‌گرده.

به جای اینکه از اول تا آخر بگرده (مثل linear search)، هر بار **نصف** فضای جستجو رو حذف می‌کنه. ⚡

> ⚠️ **پیش‌نیاز مهم:** آرایه **حتماً باید مرتب (sorted)** باشه، وگرنه جواب اشتباه می‌ده.

---

## 🧠 چجوری کار می‌کنه؟

سه تا اشاره‌گر داریم:
- `low` → ابتدای محدوده‌ی جستجو
- `high` → انتهای محدوده‌ی جستجو
- `mid` → وسط محدوده

### مراحل:

1. **وسط** محدوده (`mid`) رو حساب کن
2. اگه `array[mid] == target` → 🎉 پیدا شد، ایندکس رو برگردون
3. اگه `array[mid] < target` → برو **نیمه‌ی راست** (`low = mid + 1`)
4. اگه `array[mid] > target` → برو **نیمه‌ی چپ** (`high = mid - 1`)
5. تکرار کن تا `low > high` بشه → اگه پیدا نشد، `-1` برگردون

---

## 🎬 یه مثال بصری

فرض کن دنبال عدد **23** توی این آرایه می‌گردیم:

```
[2, 5, 8, 12, 16, 23, 38, 56, 72, 91]
 ↑                ↑                ↑
low              mid              high
```

**مرحله ۱:** `mid = 16` → `16 < 23` → برو راست ➡️

```
[2, 5, 8, 12, 16, 23, 38, 56, 72, 91]
                  ↑         ↑        ↑
                 low       mid      high
```

**مرحله ۲:** `mid = 56` → `56 > 23` → برو چپ ⬅️

```
[2, 5, 8, 12, 16, 23, 38, 56, 72, 91]
                  ↑   ↑   ↑
                 low  mid high
```

**مرحله ۳:** `mid = 23` → ✅ پیدا شد! ایندکس = **5**

---

## 💻 پیاده‌سازی

```csharp
int MyBinarySearch(int search, int[] array)
{
    int low = 0;
    int high = array.Length - 1;

    while (low <= high)
    {
        int mid = low + (high - low) / 2;

        if (array[mid] == search)
            return mid;
        else if (array[mid] < search)
            low = mid + 1;
        else
            high = mid - 1;
    }

    return -1;
}
```

### تست:

```csharp
int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
Console.WriteLine(MyBinarySearch(3, arr));   // 2
Console.WriteLine(MyBinarySearch(10, arr));  // 9
Console.WriteLine(MyBinarySearch(100, arr)); // -1
```

---

## ⏱️ پیچیدگی

| معیار | مقدار | توضیح |
|-------|-------|-------|
| ⏰ **زمان** | `O(log n)` | هر مرحله نصف می‌شه |
| 💾 **حافظه** | `O(1)` | فقط چند تا متغیر |
| 📊 **بهترین حالت** | `O(1)` | اگه وسط پیدا بشه |
| 📉 **بدترین حالت** | `O(log n)` | نصف کردن‌های پی‌درپی |

### چرا `O(log n)`؟

چون هر بار **نصف** فضای جستجو حذف می‌شه:

```
n = 1000 → 500 → 250 → 125 → ... → 1
تعداد مراحل ≈ log₂(1000) ≈ 10
```

پس برای ۱۰۰۰ عنصر، فقط **۱۰ مرحله** کافیه! 🚀

---

## ⚠️ نکات مهم

- ✅ آرایه **باید مرتب** باشه
- ✅ برای آرایه‌های بزرگ عالیه
- ❌ برای آرایه‌های کوچیک، linear search ممکنه سریع‌تر باشه
- ❌ روی لیست‌های پیوندی (linked list) کار نمی‌کنه (دسترسی تصادفی نداره)

### 💡 چرا `low + (high - low) / 2`؟

به جای `(low + high) / 2` از این استفاده می‌کنیم چون اگه `low` و `high` هر دو بزرگ باشن، `low + high` ممکنه **overflow** کنه.

---

## 📁 خروجی برنامه

```text
MyBinarySearch(3, arr)   → 2
MyBinarySearch(10, arr)  → 9
MyBinarySearch(100, arr) → -1
```

---

## 💎 جمع‌بندی

باینری سرچ یه الگوریتم ساده ولی فوق‌العاده قدرتمنده:

- 🎯 **سریع** → `O(log n)` به جای `O(n)`
- 🧠 **ساده** → فقط چند خط کد
- 🔑 **کلید اصلی** → آرایه‌ی مرتب

> یاد گرفتم که نصف کردن‌های پی‌درپی چقدر می‌تونن توی عملکرد الگوریتم تأثیر بذارن. ✨

---

<div align="center">

**Made with ❤️ while learning Algorithms**

</div>
