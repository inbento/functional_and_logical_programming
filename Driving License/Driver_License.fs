module Driver_License
open System
open System.Text.RegularExpressions

type DriverLicense( lastName: string, firstName: string, patronymic: string, birthDateAndPlace: string,
    issueDate: DateTime, expiryDate: DateTime, issuingAuthority: string, licenseNumber: string,
    address: string, categories: string) =
    
    let validate (pattern: string) (errorMessage: string) (value: string) =
        if Regex.IsMatch(value, pattern) then value
        else failwith errorMessage
    
    let validatedLastName = 
        validate @"^[А-ЯЁ][а-яё]+(-[А-ЯЁ][а-яё]+)?$" 
            "Фамилия должна начинаться с заглавной буквы и содержать только буквы и дефисы" lastName
    
    let validatedFirstName = 
        validate @"^[А-ЯЁ][а-яё]+$" 
            "Имя должно начинаться с заглавной буквы и содержать только буквы" firstName
    
    let validatedPatronymic = 
        validate @"^[А-ЯЁ][а-яё]*$" 
            "Отчество должно начинаться с заглавной буквы и содержать только буквы" patronymic
    
    let validatedBirthDateAndPlace = 
        validate @"^\d{2}\.\d{2}\.\d{4}\s[А-ЯЁа-яё\s\-.,]+$" 
            "Дата и место рождения должны быть в формате 'дд.мм.гггг Место рождения'" birthDateAndPlace
    
    let validatedIssuingAuthority = 
        validate @"^ГИБДД\s\d{4}$" 
            "Подразделение ГИБДД должно быть в формате 'ГИБДД 1234'" issuingAuthority
    
    let validatedLicenseNumber = 
        validate @"^\d{2}\s\d{2}\s\d{6}$" 
            "Номер удостоверения должен быть в формате 'xx xx xxxxxx'" licenseNumber
    
    let validatedCategories = 
        validate @"^[A-ZА-ЯЁ]( [A-ZА-ЯЁ])*$" 
            "Категории должны быть указаны через пробел (пример: A B C D)" categories
    
    do
        if expiryDate <= issueDate then
            failwith "Дата окончания действия должна быть позже даты выдачи"
    
    member _.LastName = validatedLastName
    member _.FirstName = validatedFirstName
    member _.Patronymic = validatedPatronymic
    member _.BirthDateAndPlace = validatedBirthDateAndPlace
    member _.IssueDate = issueDate
    member _.ExpiryDate = expiryDate
    member _.IssuingAuthority = validatedIssuingAuthority
    member _.LicenseNumber = validatedLicenseNumber
    member _.Address = address
    member _.Categories = validatedCategories
    
    override this.ToString() =
        let issueDateStr = this.IssueDate.ToString("dd.MM.yyyy")
        let expiryDateStr = this.ExpiryDate.ToString("dd.MM.yyyy")
        
        String.Join(Environment.NewLine,
            "Водительское удостоверение",
            "",
            $"Фамилия: {this.LastName}",
            $"Имя: {this.FirstName}",
            $"Отчество: {this.Patronymic}",
            $"Дата и место рождения: {this.BirthDateAndPlace}",
            $"Дата выдачи: {issueDateStr}",
            $"Дата окончания срока действия: {expiryDateStr}",
            $"Выдано: {this.IssuingAuthority}",
            $"Номер удостоверения: {this.LicenseNumber}",
            $"Место жительства: {this.Address}",
            $"Категории: {this.Categories}")

    interface IComparable with
        member this.CompareTo(obj) =
            match obj with
            | :? DriverLicense as other -> this.LicenseNumber.CompareTo(other.LicenseNumber)
            | _ -> -1
    
    override this.Equals(obj) =
        match obj with
        | :? DriverLicense as other -> this.LicenseNumber = other.LicenseNumber
        | _ -> false
    
    override this.GetHashCode() =
        hash licenseNumber
