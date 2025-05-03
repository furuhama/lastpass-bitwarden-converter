# LastPass to Bitwarden Converter

This is a simple F# console application that converts exported LastPass CSV files to the Bitwarden import CSV format.

## Features
- Converts credentials exported from LastPass to a format compatible with Bitwarden import
- Easy to use: just place your `lastpass.csv` in the project directory and run the tool

## Requirements
- [.NET SDK 9.0 or later](https://dotnet.microsoft.com/en-us/download)

## Usage
1. Export your credentials from LastPass as a CSV file (see [LastPass export guide](https://support.lastpass.com/help/how-do-i-export-my-vault-data-lp010121)).
2. Place the exported file as `lastpass.csv` in the root of this project directory.
3. Run the following command:
   ```sh
   dotnet run
   ```
4. The converted file `bitwarden.csv` will be generated in the same directory.
5. Import `bitwarden.csv` into Bitwarden (see [Bitwarden import guide](https://bitwarden.com/help/import-from-lastpass-csv/)).

## Notes
- Only basic login credentials are supported (URL, username, password, notes, folder, favorite).
- Custom fields and attachments are not supported.
- The output file will overwrite any existing `bitwarden.csv` in the directory.

## License
MIT
