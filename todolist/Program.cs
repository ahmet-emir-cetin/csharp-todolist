List<todo> todoList = new List<todo>();
string select;
int _id;
string _title;
string _isComplated;

while (true)
{
    Console.WriteLine("Yapmak istegiğiniz işlem: \n[0] Çıkış \n[1] Listele \n[2] Ekle \n[3] Düzenle \n[4] Sil");
    select = Console.ReadLine()!;
    switch (select)
    {
        case "0":
            cikis();
            break;
        case "1":
            listele(todoList);
            continue;

        case "2":
            ekle();
            continue;

        case "3":
            düzenle();
            continue;

        case "4":
            sil();
            Console.WriteLine("Kaydınız Başarıyla Silindi");

            continue;

        default:
            Console.WriteLine("0-4 arasında bir değer giriniz");
            continue;
    }
}
void cikis()
{
    Console.WriteLine("Güle Güle...");
    Environment.Exit(0);
}
void düzenle()
{
    Console.Write("Düzenlemek istediğiniz id'i giriniz :");
    _id = int.Parse(Console.ReadLine()!);
    Console.Write("Yeni başlığı giriniz :");
    _title = Console.ReadLine()!;
    todo Todo = todoList.Find(x => x.id == _id)!;
    Console.Write("Görev tamamlandı mı? (E/H)");
    _isComplated = Console.ReadLine()!.ToUpper();
    if (Todo != null)
    {
        if (_isComplated=="E")
        {
            Todo.isComplated = true;
        }
        else if(_isComplated=="H")
        {
            Todo.isComplated = false;
        }
        Todo.title = _title;
        Console.WriteLine("Kaydınız Başarıyla Değiştirildi");
    }
    else
    {
        Console.WriteLine("Düzenlemek istediğiniz id'e ait bilgiler bulunamadı");
    }
}
void sil()
{
    Console.Write("Silmek istediğiniz id'i giriniz :");
    _id = int.Parse(Console.ReadLine()!);
    todo Todo = todoList.Find(x => x.id == _id)!;

    if (Todo != null)
    {
        todoList.Remove(Todo);
        Console.WriteLine("Kayıt başarıyla silindi");
    }
    else
    {
        Console.WriteLine("Silmek istediğiniz id'e ait bilgiler bulunamadı");
    }
}
void ekle()
{
    Console.Write("Başlık :");
    _title = Console.ReadLine()!;
    if (todoList.Count > 0)
    {
        _id = todoList.Last().id + 1;
    }
    else
    {
        _id = 1;
    }
    todo Todo = new todo(_id, _title, false);
    todoList.Add(Todo);
    Console.WriteLine("Kaydınız Başarıyla Eklendi");
}

void listele(List<todo> todoList)
{
    if (todoList.Count > 0)
    {
        foreach (var item in todoList)
        {
            Console.WriteLine("ID\tBASLIK\t\tDurum");
            Console.WriteLine(item.id + "\t" + item.title + "\t\t" + item.isComplated);
        }
    }
    else
    {
        Console.WriteLine("Kayıt bulunamadı");
    }
}