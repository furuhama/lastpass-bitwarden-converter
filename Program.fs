open System.IO

// LastPass CSVのカラム順（公式: https://support.lastpass.com/help/how-do-i-export-my-vault-data-lp010121）
// url,username,password,extra,name,grouping,fav
// Bitwarden CSVのカラム順（公式: https://bitwarden.com/help/import-from-lastpass-csv/）
// folder,favorite,type,name,notes,fields,login_uri,login_username,login_password,login_totp

let lastpassToBitwarden (inputPath: string) (outputPath: string) =
    let lines = File.ReadAllLines(inputPath)

    let header =
        "folder,favorite,type,name,notes,fields,login_uri,login_username,login_password,login_totp"

    let convertLine (line: string) =
        let parts = line.Split(',')

        if parts.Length < 7 then
            None
        else
            // LastPass: url,username,password,extra,name,grouping,fav
            // Bitwarden: folder,favorite,type,name,notes,fields,login_uri,login_username,login_password,login_totp
            let folder = parts.[5]
            let favorite = if parts.[6] = "1" then "1" else "0"
            let type_ = "login"
            let name = parts.[4]
            let notes = parts.[3]
            let fields = ""
            let login_uri = parts.[0]
            let login_username = parts.[1]
            let login_password = parts.[2]
            let login_totp = ""

            Some(
                sprintf
                    "%s,%s,%s,%s,%s,%s,%s,%s,%s,%s"
                    folder
                    favorite
                    type_
                    name
                    notes
                    fields
                    login_uri
                    login_username
                    login_password
                    login_totp
            )

    let converted =
        lines
        |> Seq.skip 1 // skip header
        |> Seq.choose convertLine
        |> Seq.toList

    File.WriteAllLines(outputPath, header :: converted)
    printfn "変換が完了しました: %s → %s" inputPath outputPath

[<EntryPoint>]
let main argv =
    let input = "lastpass.csv"
    let output = "bitwarden.csv"

    if File.Exists(input) then
        lastpassToBitwarden input output
    else
        printfn "lastpass.csv が見つかりませんでした。"

    0
