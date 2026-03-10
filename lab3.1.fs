open System

// Получить последовательность из первых цифр чисел, содержащихся в исходном списке

let rec ToNatural (): int = 
    let st = Console.ReadLine()
    let success, result = Int32.TryParse(st:string)
    if success && result > 0 then
        result
    else
        printf "Некорректный ввод, введите натуральное число ещё раз: "
        ToNatural ()

let rec ToInt (): int = 
    let st = Console.ReadLine()
    let success, result = Int32.TryParse(st:string)
    if success then
        result
    else
        printf "Некорректный ввод, введите целое число ещё раз: "
        ToInt ()

let rec input n = 
    printf "Введите первое число: "
    let first_num = ToInt ()
    printf "Введите последнее число: "
    let last_num = ToInt ()
    if first_num<last_num then
       printf "Введите шаг между членами: "
       let step = ToNatural ()
       seq { first_num..step..last_num }
     else 
        printfn "Некорректный ввод, введите первое и последнее числа заново "
        input ()

// Функция нахождения первой цифры числа
let First_Digit input =
    let abs_input = abs input
    let rec Get_First_Digit numb =
        if numb<10 then
            numb
        else 
            Get_First_Digit (numb/10)
    Get_First_Digit abs_input


[<EntryPoint>]
let main _ =
    printfn "Программа создает последовательность из первых цифр исходной последовательности "
    let Seq_of_Numbs = input() 
    let Seq_of_Difits = Seq.map First_Digit (Seq_of_Numbs)
    printfn "Исходный список: %A" Seq_of_Numbs
    printfn "Cписок первых цифр из чисел исходного списка: %A" Seq_of_Difits
    0