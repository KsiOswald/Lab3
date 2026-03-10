open System

// Сколько раз в списке встречается заданное число? 

let rec ToFloat () : float =
    let input =  Console.ReadLine()
    let success, result = Double.TryParse(input)
    if success then
        result
    else
        printf "Некорректный ввод, введите целое число ещё раз: "
        ToFloat ()


let rec input n = 
    printf "Введите первое число: "
    let first_num = ToFloat ()
    printf "Введите последнее число: "
    let last_num = ToFloat ()
    if first_num<last_num then
       printf "Введите шаг между членами: "
       let step = ToFloat ()
       seq { first_num..step..last_num }
     else 
        printfn "Некорректный ввод, введите первое и последнее числа заново "
        input ()

let search seqv: int =
    printf "Введите искомое число: "
    let find_num = ToFloat()
    let quantity_of_occ = Seq.fold(fun coun elemen_of_seq -> 
        if elemen_of_seq = find_num then
            coun+1 else coun) 0 seqv
    quantity_of_occ

[<EntryPoint>]
let main _ =
    printfn "Программа находит количество вхождений определнного числа в последовательность "
    let Seq_of_Numbs = input()
    let result = search Seq_of_Numbs
    printfn "Последовательность для поиска: %A" Seq_of_Numbs
    printf "Количество совпадений: %i" result
    0