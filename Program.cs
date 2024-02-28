//Ввести строки з файлу, записати в список. Вивести строки у файл у зворотному порядку.


using System.Text.Json;

string readFile(string path){
    StreamReader sr = new StreamReader(path);
    string text = sr.ReadToEnd();
    sr.Close();
    return text;
    
}

List<string> collection = new List<string>();
try{
    collection.AddRange(readFile("text.txt").Split(' '));
}catch(Exception ex){
    Console.WriteLine(ex.Message);
}


void reverseList(List<string> list){
    list.Reverse();
}

Console.WriteLine("Normal list");
foreach(var i in collection){
    Console.WriteLine(i);
}


reverseList(collection);

Console.WriteLine("Reversed list");
foreach(var i in collection){
    Console.WriteLine(i);
}


//Об’єднати два словники, додаючи значення для спільних ключів. d1 = {'a': 100, 'b': 200, 'c':300} 
//d2 = {'a': 300, 'b': 200, 'd':400}. Вихідний результат:{'a': 400, 'b': 400, 'd': 400, 'c': 300}


Dictionary<string,int> dic1 = new Dictionary<string, int>();
dic1.Add("a", 300);
dic1.Add("b", 600);
dic1.Add("c", 100);

Console.WriteLine("Dic1: ");
foreach(var item in dic1){
    Console.WriteLine($"Key:{item.Key}, Value:{item.Value}");
}

Dictionary<string,int> dic2 = new Dictionary<string, int>();
dic2.Add("a", 200);
dic2.Add("b", 50);
dic2.Add("d", 500);

Console.WriteLine("Dic2: ");
foreach(var item in dic2){
    Console.WriteLine($"Key:{item.Key}, Value:{item.Value}");
}

Dictionary<string, int> sumOfDictionaries(Dictionary<string,int> dic1,Dictionary<string,int> dic2){
    Dictionary<string, int> dicSum = new Dictionary<string, int>(dic1);

    foreach(var item in dic2){
        if(dicSum.ContainsKey(item.Key)){
            dicSum[item.Key] += item.Value;
        }else{
            dicSum.Add(item.Key, item.Value);
        }
    }

    return dicSum;
}

Console.WriteLine($"Sum of two dictionaries in JSON: ");

Console.WriteLine(JsonSerializer.Serialize(sumOfDictionaries(dic1,dic2)));

//Дана послідовність цілих чисел. 
//Витягти з неї всі парні від'ємні числа, помінявши порядок витягнутих чисел на зворотний. 

List<int> numbers = new List<int>();
Random random = new Random();

for (int i = 0; i < 20; i++) 
{
    int randomNumber = random.Next(-500, 100); 
    numbers.Add(randomNumber); 
}

Console.WriteLine("Collections of numbers: ");
foreach(int number in numbers){
    Console.WriteLine(number);
}

var filteredAndOrderedList = numbers.Where(number => number < 0 && number % 2 == 0).OrderByDescending(number => number);

Console.WriteLine("Filtered and ordered list: ");
foreach(int number in filteredAndOrderedList){
    Console.WriteLine(number);
}


Console.Read();