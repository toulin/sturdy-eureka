### 測試目的
了解注入的介面被實例化的時機

---
### 結論
一、注入的實例化時機，是看表單的建立方式，若是使用Application.Run(new Form1());，則在呼叫Application.Run的時候，就會實例化注入的介面，且在呼叫Application.Run之前，就會實例化注入的介面。
所以直接在program.cs中實例化注入的介面，不論是使用哪方式呼叫，都會是同一個實例，且在程式啟動時，就先實例化了。

二、若要在呼叫的時候才實例化表單時，可以參考本案例FormFactory實作方式

使用本方式時，若要每次呼叫都是新實例，則在注入時，使用AddTransient，若要每次呼叫都是同一個實例，則在注入時，使用AddSingleton。

三、繼第二點，若每次呼叫都是新實例表單時，該表單所注入的介面，就會受到AddTransient、AddScoped、AddSingleton的影響，
若每次呼叫都是同一個實例表單時，該表單所注入的介面，就不會受到AddTransient、AddScoped、AddSingleton的影響

----
### 線上資源
https://stackoverflow.com/questions/70475830/how-to-use-dependency-injection-in-winforms

https://andrewlock.net/the-difference-between-getservice-and-getrquiredservice-in-asp-net-core/