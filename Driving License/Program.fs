open System
open Driver_License


let test() =
    let license1 = DriverLicense(
        lastName = "Миков",
        firstName = "Никита",
        patronymic = "Сергеевич",
        birthDateAndPlace = "03.03.2003 г. Москва",
        issueDate = DateTime(2020, 1, 1),
        expiryDate = DateTime(2030, 1, 1),
        issuingAuthority = "ГИБДД 1234",
        licenseNumber = "12 34 567890",
        address = "г. Москва, ул. Ленина, д. 1",
        categories = "B С M")
    
    Console.WriteLine(license1)

    let license2 = DriverLicense(
        lastName = "Бимбим",
        firstName = "Бамбам",
        patronymic = "Парампам",
        birthDateAndPlace = "11.11.2011 г. Воронеж",
        issueDate = DateTime(2024, 2, 4),
        expiryDate = DateTime(2034, 2, 4),
        issuingAuthority = "ГИБДД 5678",
        licenseNumber = "56 78 901234",
        address = "г. Воронеж, ул. Ленина, д. 21",
        categories = "A B C")

    Console.WriteLine(license2)

    Console.WriteLine($"ВУ1 = ВУ2 {license1.Equals(license2)}")
    Console.WriteLine($"ВУ1 = ВУ1 {license1.Equals(license1)}")
    Console.WriteLine($"ВУ1 > ВУ2 {license1 > license2}")

[<EntryPoint>]
let main argv =

    test()

    0