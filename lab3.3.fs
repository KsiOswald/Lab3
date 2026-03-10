open System
open System.IO

// Функция для ввода пути
let rec inputPath () =
    printf "Введите путь к папке: "
    let path = Console.ReadLine()
    
    // Проверяем, существует ли такая папка на диске
    if Directory.Exists(path) then
        path
    else
        printfn "Такой папки не существует. Попробуйте снова."
        inputPath ()

[<EntryPoint>]
let main _ =
    printfn "Программа ищет .txt файлы на диске пользователя"
    
    // Получаем путь от пользователя
    let folder = inputPath()
    // Создаем настройки поиска
    let options = EnumerationOptions()
    options.RecurseSubdirectories <- true     // Искать во всех подпапках
    options.IgnoreInaccessible <- true        // Игнорировать ошибки доступ
    let allFiles = Directory.EnumerateFiles(folder, "*.txt", options)
    
    printfn "\nПоследовательность найденных путей:"
    
    // Вывод пути на экран
    allFiles |> Seq.iter (printfn "%s")
    
    printfn "\nГотово!"
    0