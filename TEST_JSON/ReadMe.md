### 反序列測試結果
Newtonsoft 耗時:38 ms, 資料筆數=1806
Json.Net 耗時:42 ms, 資料筆數=1806
fastJSON 耗時:27 ms, 資料筆數=1806
Jil 耗時:185 ms, 資料筆數=1806

Jil 最慢，fastJSON 最快

### 序列測試結果
Newtonsoft 序列化耗時:27 ms
Json.Net 序列化耗時:26 ms
fastJSON 序列化耗時:13 ms
Jil 序列化耗時:112 ms

Jil 最慢，fastJSON 最快

### 反序列化後的物件資料比對
由於測試案例文字由 Newtonsofe產生，故以Newtonsoft為基準，比對其他三個序列化結果是否相同
結果並不一致，主要是因為{} 這個符號造成，其他資料都是一致的

data1.list[20]={} ; data2.list[20]=System.Dynamic.ExpandoObject
Json.Net 校對NG
data1.list[20]={} ; data2.list[20]=System.Collections.Generic.Dictionary`2[System.String,System.Object]
fastJSON 校對NG


### 結論 不推薦使用Jil，推薦使用fastJSON