## 本示例在示範，如何將excel上的JSON格式資料，透過JObject轉換成指定泛型的List集合

#### 情境說明
某專案會將資料集合(類別SampleClassA)資料存放於Excel上，而存放是將每一個公開屬性依序存放在每一欄

#### 示例方法 
帶入欄位名稱陣列和資料陣列，透過JObject轉換成指定泛型的List集合

---

### 當屬性中有類別型態該如何處理？
新增一個類別繼承JsonConverter<T>，並實作ReadJson方法，將資料轉換成指定的類別

如本示例中的 ClassBConverter類別

---

### 調整後的擴充方法 (二維陣列的擴充方法)

 1. 該陣列需含有欄位名稱，且欄位名稱需放在第一列
 2. 此陣列可由將Excel上的資料轉換為二維陣列得到
 3. 第一維度為資料列, 第二維度為欄位


	    /// <summary>
        /// 將二維陣列轉換成List<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this object[,] values)
        {
            List<T> list = new List<T>();
            //取得欄位名稱
            List<string> fieldNames = new List<string>();
            for (int i = 0; i < values.GetLength(1); i++)
            {
                fieldNames.Add(values[1, i + 1].ToString());
            }
            //取得資料
            for (int i = 1; i < values.GetLength(0); i++)
            {
                JObject jObject = new JObject();
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    jObject.Add(fieldNames[j], values[i + 1, j + 1]?.ToString());
                }
                list.Add(jObject.ToObject<T>());
            }
            return list;
        }