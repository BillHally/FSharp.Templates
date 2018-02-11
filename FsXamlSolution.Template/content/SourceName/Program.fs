open System
open FsXaml

type App = XAML<"App.xaml">
type MainWindow = XAML<"MainWindow.xaml">

[<STAThread>]
[<EntryPoint>]
let main __ =
    let application = App()
    let mainWindow = MainWindow()
    application.Run mainWindow
