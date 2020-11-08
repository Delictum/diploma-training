unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.DB, mySQLDbTables, Vcl.Grids,
  Vcl.DBGrids, Vcl.ComCtrls, Vcl.StdCtrls, Data.Win.ADODB, Vcl.DBCtrls,
  Vcl.ExtCtrls, Vcl.Mask, ExcelXP, ComObj, VclTee.TeeGDIPlus, VCLTee.TeEngine,
  VCLTee.Series, VCLTee.TeeProcs, VCLTee.Chart, VCLTee.DBChart,
  FireDAC.Stan.Intf, FireDAC.Stan.Option, FireDAC.Stan.Error, FireDAC.UI.Intf,
  FireDAC.Phys.Intf, FireDAC.Stan.Def, FireDAC.Stan.Pool, FireDAC.Stan.Async,
  FireDAC.Phys, FireDAC.Phys.MySQL, FireDAC.Phys.MySQLDef, FireDAC.VCLUI.Wait,
  FireDAC.Stan.Param, FireDAC.DatS, FireDAC.DApt.Intf, FireDAC.DApt,
  Data.DBXMySQL, Data.FMTBcd, Datasnap.DBClient, Datasnap.Provider,
  Data.SqlExpr, FireDAC.Comp.DataSet, FireDAC.Comp.Client;

type
  TForm1 = class(TForm)
    PageControl1: TPageControl;
    TabSheet1: TTabSheet;
    TabSheet2: TTabSheet;
    TabSheet3: TTabSheet;
    DBGrid1: TDBGrid;
    DBGrid2: TDBGrid;
    DBGrid3: TDBGrid;
    MySQLDatabase1: TMySQLDatabase;
    MySQLQuery1: TMySQLQuery;
    MySQLQuery2: TMySQLQuery;
    MySQLQuery3: TMySQLQuery;
    DataSource1: TDataSource;
    DataSource2: TDataSource;
    DataSource3: TDataSource;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    DBNavigator1: TDBNavigator;
    DBLookupListBox1: TDBLookupListBox;
    Edit3: TEdit;
    Edit2: TEdit;
    DBLookupComboBox1: TDBLookupComboBox;
    DBLookupComboBox2: TDBLookupComboBox;
    Label2: TLabel;
    Button5: TButton;
    Edit4: TEdit;
    Edit6: TEdit;
    Edit5: TEdit;
    Button4: TButton;
    DBEdit1: TDBEdit;
    Button6: TButton;
    OpenDialog1: TOpenDialog;
    DateTimePicker1: TDateTimePicker;
    Button8: TButton;
    MySQLQuery4: TMySQLQuery;
    DataSource4: TDataSource;
    DBChart1: TDBChart;
    Series1: TBarSeries;
    DBGrid4: TDBGrid;
    DBGrid5: TDBGrid;
    DBGrid6: TDBGrid;
    DataSource6: TDataSource;
    FDConnection1: TFDConnection;
    FDQuery1: TFDQuery;
    DataSource5: TDataSource;
    ADOQuery1: TADOQuery;
    ADOConnection1: TADOConnection;
    SQLConnection1: TSQLConnection;
    SQLQuery1: TSQLQuery;
    DataSetProvider1: TDataSetProvider;
    ClientDataSet1: TClientDataSet;
    DataSource7: TDataSource;
    Button7: TButton;
    procedure DataSource1DataChange(Sender: TObject; Field: TField);
    procedure Button5Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Edit6KeyPress(Sender: TObject; var Key: Char);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button8Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

function ParseDate(DateTime : string) : string;
  Var newStr, day, month, year : string;
begin
  day := copy(DateTime, 1, 2);
  month := copy(DateTime, 4, 2);
  year := copy(DateTime, 7, 4);
  newStr := year + '-' + month + '-' + day;
  ParseDate := newStr;
end;

procedure TForm1.Button1Click(Sender: TObject);
Var bufName1, bufName2 : string;
      bufId   : integer;
begin
    DBEdit1.DataField := '';
    DataSource1.OnDataChange := DataSource2.OnDataChange;

    MySQLQuery1.Close;
    MySQLQuery1.SQL.Clear;
    MySQLQuery1.SQL.Add('SELECT id FROM namedish WHERE name = "' + DBLookupComboBox1.Text + '"');
    MySQLQuery1.Open;
    bufName1 := VarToStr(MySQLQuery1.FieldValues['id']);

    DBEdit1.DataField := '';
    DataSource1.OnDataChange := DataSource3.OnDataChange;

    MySQLQuery1.Close;
    MySQLQuery1.SQL.Clear;
    MySQLQuery1.SQL.Add('SELECT id FROM typedish WHERE type = "' + DBLookupComboBox2.Text + '"');
    MySQLQuery1.Open;
    bufName2 := VarToStr(MySQLQuery1.FieldValues['id']);

    MySQLQuery1.Close;
    MySQLQuery1.SQL.Clear;
    MySQLQuery1.SQL.Add('SELECT MAX(id) AS ID FROM menu');
    MySQLQuery1.Open;
    bufId := MySQLQuery1.FieldValues['ID'] + 1;

    MySQLQuery1.Close;
    MySQLQuery1.SQL.Clear;
    MySQLQuery1.SQL.Add
      ('INSERT INTO menu(id, namedishid, typedishid, date, cost, count, vat) VALUES (');
    MySQLQuery1.SQL.Add(IntToStr(bufId) + ', ' + bufName1 + ', ' + bufName2 +
      ', "' + ParseDate(DateTimeToStr(DateTimePicker1.DateTime)) + '", ' + Edit2.Text + ', ' + Edit3.Text + ', 1)');
    MySQLQuery1.ExecSQL;

    MySQLQuery1.Close;
    MySQLQuery1.SQL.Clear;
    MySQLQuery1.SQL.Add('SELECT menu.id, date, namedish.Name, typedish.Type, cost, count, VAT FROM menu, namedish, typedish  WHERE namedish.Id = menu.NameDishId AND typedish.Id = menu.TypeDishId');
    MySQLQuery1.Open;

    DBEdit1.DataField := 'id';
    DataSource1.OnDataChange := DataSource1DataChange;
    ShowMessage('Запись успешно добавлена.');
end;

procedure TForm1.Button2Click(Sender: TObject);
Var bufName1, bufName2, bufId : string;
begin
    bufId := DBEdit1.Text;
    DBEdit1.DataField := '';
    DataSource1.OnDataChange := DataSource2.OnDataChange;

    MySQLQuery1.Close;
    MySQLQuery1.SQL.Clear;
    MySQLQuery1.SQL.Add('SELECT id FROM namedish WHERE name = "' + DBLookupComboBox1.Text + '"');
    MySQLQuery1.Open;
    bufName1 := VarToStr(MySQLQuery1.FieldValues['id']);

    DBEdit1.DataField := '';
    DataSource1.OnDataChange := DataSource3.OnDataChange;

    MySQLQuery1.Close;
    MySQLQuery1.SQL.Clear;
    MySQLQuery1.SQL.Add('SELECT id FROM typedish WHERE type = "' + DBLookupComboBox2.Text + '"');
    MySQLQuery1.Open;
    bufName2 := VarToStr(MySQLQuery1.FieldValues['id']);

    MySQLQuery1.Close;
    MySQLQuery1.SQL.Clear;
    MySQLQuery1.SQL.Add('UPDATE menu Set date = "' + ParseDate(DateTimeToStr(DateTimePicker1.DateTime)) +
    '", namedishid = ' +
      bufName1 + ', typedishid = ' + bufName2 +
      ', cost = ' + Edit2.Text + ', count = ' +
      Edit3.Text + ', VAT = 1 WHERE id = ' + bufId);
    MySQLQuery1.ExecSQL;

    MySQLQuery1.Close;
    MySQLQuery1.SQL.Clear;
    MySQLQuery1.SQL.Add('SELECT menu.id, date, namedish.Name, typedish.Type, cost, count, VAT FROM menu, namedish, typedish  WHERE namedish.Id = menu.NameDishId AND typedish.Id = menu.TypeDishId');
    MySQLQuery1.Open;

    DBEdit1.DataField := 'id';
    DataSource1.OnDataChange := DataSource1DataChange;
    ShowMessage('Запись успешно изменена.');
end;

procedure TForm1.Button3Click(Sender: TObject);
    Var bufName, bufId : string;
begin
    bufId := DBEdit1.Text;
    DBEdit1.DataField := '';
    DataSource1.OnDataChange := DataSource2.OnDataChange;

    MySQLQuery1.Close;
    MySQLQuery1.SQL.Clear;
    MySQLQuery1.SQL.Add('DELETE FROM menu WHERE id = ' + bufId);
    MySQLQuery1.ExecSQL;

    MySQLQuery1.Close;
    MySQLQuery1.SQL.Clear;
    MySQLQuery1.SQL.Add('SELECT menu.id, date, namedish.Name, typedish.Type, cost, count, VAT FROM menu, namedish, typedish  WHERE namedish.Id = menu.NameDishId AND typedish.Id = menu.TypeDishId');
    MySQLQuery1.Open;

    DBEdit1.DataField := 'id';
    DataSource1.OnDataChange := DataSource1DataChange;
    ShowMessage('Запись успешно удалена.');
end;

//Поиск по Locate по полю Date
procedure TForm1.Button4Click(Sender: TObject);
begin
    DBGrid1.DataSource.DataSet.Locate('date', VarArrayOf([edit5.Text]),
    [loCaseInsensitive, loPartialKey]);
end;

//Поиск по Lookup по полю Count
procedure TForm1.Button5Click(Sender: TObject);
begin
    if VarType(MySQLQuery1.Lookup('count', Edit4.Text, 'cost')) <> VarNull then
      ShowMessage('Cost: ' +
        VarToStr(MySQLQuery1.Lookup('count', Edit4.Text,
        'Cost')) + ', VAT: ' +
        VarToStr(MySQLQuery1.Lookup('count', Edit4.Text,
        'VAT')))
    else
      ShowMessage('Data not found');
end;

//Вывод в Excel
procedure TForm1.Button6Click(Sender: TObject);
Var i,j,index: Integer;
      ExcelApp,sheet: Variant;
begin
    ExcelApp := CreateOleObject('Excel.Application');
    ExcelApp.Visible := false;
    ExcelApp.WorkBooks.Add(-4167);
    ExcelApp.WorkBooks[1].WorkSheets[1].name := 'Export';
    sheet := ExcelApp.WorkBooks[1].WorkSheets['Export'];
    index := 2;
    sheet.cells[1, 1] := 'Date';
    sheet.cells[1, 2] := 'Name';
    sheet.cells[1, 3] := 'Type';
    sheet.cells[1, 4] := 'Cost';
    sheet.cells[1, 5] := 'Count';
    sheet.cells[1, 6] := 'Vat';
    sheet.Columns[1].ColumnWidth := 20;
    sheet.Columns[2].ColumnWidth := 20;
    sheet.Columns[3].ColumnWidth := 20;
    sheet.Columns[4].ColumnWidth := 10;
    sheet.Columns[5].ColumnWidth := 20;
    sheet.Columns[6].ColumnWidth := 20;

    DBGrid1.DataSource.DataSet.First;
    for i := 1 to DBGrid1.DataSource.DataSet.RecordCount do
    begin
      for j := 1 to DBGrid1.FieldCount do
        sheet.cells[index, j] := DBGrid1.fields[j - 1].asstring;
      inc(index);
      DBGrid1.DataSource.DataSet.Next;
    end;
    ExcelApp.Visible := true;
end;

procedure TForm1.Button7Click(Sender: TObject);
begin
    MySQLQuery1.Close;
    MySQLQuery1.SQL.Clear;
    MySQLQuery1.SQL.Add('SELECT menu.id, date, namedish.Name, typedish.Type, cost, count, VAT FROM menu, namedish, typedish  WHERE namedish.Id = menu.NameDishId AND typedish.Id = menu.TypeDishId');
    MySQLQuery1.Open;

    MySQLQuery4.Close;
    MySQLQuery4.SQL.Clear;
    MySQLQuery4.SQL.Add('SELECT menu.id, date, namedish.Name, typedish.Type, cost, count, VAT FROM menu, namedish, typedish  WHERE namedish.Id = menu.NameDishId AND typedish.Id = menu.TypeDishId');
    MySQLQuery4.Open;
end;

procedure TForm1.Button8Click(Sender: TObject);
Var Od : TOpenDialog;
      exApp, exBook, exSh : OleVariant;
      FileName : string;
      i,j,index: Integer;
begin
  //Диалог выбора файла.
  Od := OpenDialog1; //OpenDialog1 уже должен быть на форме.
  if Od.InitialDir = '' then //В качестве начальной выбираем папку, в которой лежит исполняемый файл программы.
    Od.InitialDir := ExtractFilePath(ParamStr(0));
  if not Od.Execute then //Диалог выбора файла.
    Exit;
  if not FileExists(Od.FileName) then //Проверка существования файла.
  begin
    MessageBox(Handle, 'Файл с заданным именем не найден! Действие отменено.',
      'Внимание!', MB_OK + MB_ICONEXCLAMATION + MB_APPLMODAL);
    Exit;
  end;

  //Запуск экземпляра Excel и получение ссылки на интерфейс корневого объекта (Excel.Application).
  exApp := CreateOleObject('Excel.Application');
  //Делаем видимым окно MS Excel. На время отладки или на постоянной основе.
  exApp.Visible := True;
  //Открываем раб. книгу и получаем ссылку на её интерфейс.
  exBook := exApp.Workbooks.Open(FileName:=Od.FileName);
  //Ссылка на интерфейс первого листа рабочей книги.
  exSh := exBook.Worksheets[1];

    index := 2;
    exSh.cells[2, 1].Value := 'Date';
    exSh.cells[2, 2].Value := 'Name dish';
    exSh.cells[2, 3].Value := 'Type dish';
    exSh.cells[2, 4].Value := 'Cost';
    exSh.cells[2, 5].Value := 'Count';
    exSh.cells[2, 6].Value := 'VAT';
    exSh.Columns[1].ColumnWidth := 20;
    exSh.Columns[2].ColumnWidth := 20;
    exSh.Columns[3].ColumnWidth := 20;
    exSh.Columns[4].ColumnWidth := 10;
    exSh.Columns[5].ColumnWidth := 10;
    exSh.Columns[6].ColumnWidth := 10;

    DBGrid1.DataSource.DataSet.First;
    for i := 1 to DBGrid1.DataSource.DataSet.RecordCount do
    begin
      for j := 1 to DBGrid1.FieldCount do
        exSh.cells[index, j].Value := DBGrid1.fields[j - 1].asstring;
      inc(index);
      DBGrid1.DataSource.DataSet.Next;
    end;
end;

//Отображение текста текущей строки в Edit
procedure TForm1.DataSource1DataChange(Sender: TObject; Field: TField);
begin
    Edit2.Text := DBGrid1.Fields[4].AsString;
    Edit3.Text := DBGrid1.Fields[5].AsString;
end;

//Поиск при вводе через SQL 'LIKE'
procedure TForm1.Edit6KeyPress(Sender: TObject; var Key: Char);
begin
    MySQLQuery1.Close;
    MySQLQuery1.SQL.Clear;
    MySQLQuery1.SQL.Add
      ('SELECT menu.id, date, namedish.Name, typedish.Type, cost, count, VAT ' +
       'FROM menu, namedish, typedish  WHERE namedish.Id = menu.NameDishId AND typedish.Id = menu.TypeDishId ' +
       'AND cost LIKE "%' + edit6.Text + '%"');
    MySQLQuery1.Open;
end;

end.
