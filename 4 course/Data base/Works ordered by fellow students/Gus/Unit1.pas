unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.DB, Data.DBXMySQL, Data.FMTBcd,
  Datasnap.Provider, Datasnap.DBClient, Data.SqlExpr, Vcl.Grids, Vcl.DBGrids,
  Vcl.StdCtrls, Vcl.Mask, Vcl.DBCtrls, Vcl.ComCtrls, ExcelXP, ComObj,
  Vcl.ExtCtrls, VclTee.TeeGDIPlus, FireDAC.Stan.Intf, FireDAC.Stan.Option,
  FireDAC.Stan.Error, FireDAC.UI.Intf, FireDAC.Phys.Intf, FireDAC.Stan.Def,
  FireDAC.Stan.Pool, FireDAC.Stan.Async, FireDAC.Phys, FireDAC.Phys.MySQL,
  FireDAC.Phys.MySQLDef, FireDAC.VCLUI.Wait, FireDAC.Stan.Param, FireDAC.DatS,
  FireDAC.DApt.Intf, FireDAC.DApt, mySQLDbTables, Data.Win.ADODB,
  FireDAC.Comp.DataSet, FireDAC.Comp.Client, VCLTee.TeEngine, VCLTee.Series,
  VCLTee.TeeProcs, VCLTee.Chart, VCLTee.DBChart;

type
  TForm1 = class(TForm)
    SQLConnection1: TSQLConnection;
    SQLQuery1: TSQLQuery;
    ClientDataSet1: TClientDataSet;
    DataSetProvider1: TDataSetProvider;
    DataSource1: TDataSource;
    DBGrid1: TDBGrid;
    SQLQuery2: TSQLQuery;
    DataSetProvider2: TDataSetProvider;
    ClientDataSet2: TClientDataSet;
    DataSource2: TDataSource;
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    DBEdit1: TDBEdit;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Edit4: TEdit;
    Edit5: TEdit;
    DBLookupListBox1: TDBLookupListBox;
    Label2: TLabel;
    Edit6: TEdit;
    DBGrid2: TDBGrid;
    DateTimePicker1: TDateTimePicker;
    Edit7: TEdit;
    DBLookupComboBox1: TDBLookupComboBox;
    Button8: TButton;
    DBChart1: TDBChart;
    Series1: TBarSeries;
    SQLQuery3: TSQLQuery;
    DataSetProvider3: TDataSetProvider;
    ClientDataSet3: TClientDataSet;
    DataSource3: TDataSource;
    DBGrid4: TDBGrid;
    FDConnection1: TFDConnection;
    FDQuery1: TFDQuery;
    DataSource6: TDataSource;
    MySQLDatabase1: TMySQLDatabase;
    ADOConnection1: TADOConnection;
    ADOQuery1: TADOQuery;
    DataSource5: TDataSource;
    DataSource7: TDataSource;
    MySQLQuery1: TMySQLQuery;
    DBGrid3: TDBGrid;
    DBGrid5: TDBGrid;
    Button7: TButton;
    OpenDialog1: TOpenDialog;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Edit6KeyPress(Sender: TObject; var Key: Char);
    procedure DataSource1DataChange(Sender: TObject; Field: TField);
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


procedure TForm1.Button1Click(Sender: TObject);
  Var bufName : string;
      bufId   : integer;
begin
    ClientDataSet1.Active := false;
    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add('SELECT id FROM namepayments WHERE name = "' + DBLookupComboBox1.Text + '"');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
    bufName := VarToStr(SQLQuery1.FieldValues['id']);

    ClientDataSet1.Active := false;
    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add('SELECT MAX(id) AS ID FROM monthcommunalpayments');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
    bufId := SQLQuery1.FieldValues['ID'] + 1;

    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add
      ('INSERT INTO monthcommunalpayments(id, datePayments, namePayments, '
      +'numberPayments, fullName, adress, sum) VALUES (');
    SQLQuery1.SQL.Add(IntToStr(bufId) + ', "' + DateToStr(DateTimePicker1.Date) + '", ' + bufName + ', ' + Edit1.Text +
      ', "' + Edit2.Text + '", "' + Edit3.Text + '", ' + Edit7.Text + ')');
    SQLQuery1.ExecSQL;

    ClientDataSet1.Active := false;
    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add
      ('SELECT monthcommunalpayments.id, monthcommunalpayments.datePayments, '
      +'namepayments.name, monthcommunalpayments.numberPayments, '
      +'monthcommunalpayments.fullName, monthcommunalpayments.adress, monthcommunalpayments.sum '
      +'FROM monthcommunalpayments '
      +'INNER JOIN namepayments ON monthcommunalpayments.namePayments=namepayments.id;');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
    ShowMessage('������ ������� ���������.');
  end;

procedure TForm1.Button2Click(Sender: TObject);
  Var bufName, bufId : string;
begin
    bufId := DBEdit1.Text;
    DBEdit1.DataField := '';

    ClientDataSet1.Active := false;
    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add('SELECT id FROM namepayments WHERE name = "' + DBLookupComboBox1.Text + '"');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
    bufName := VarToStr(SQLQuery1.FieldValues['id']);

    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add('UPDATE monthcommunalpayments Set datePayments = "' +
      DateToStr(DateTimePicker1.Date) + '", namePayments = ' + bufName +
      ', numberPayments = ' + Edit1.Text + ', fullName = "' + Edit2.Text +
      '", adress = "' + Edit3.Text + '", sum = ' + Edit7.Text +
      ' WHERE id = ' + bufId);
    SQLQuery1.ExecSQL;

    ClientDataSet1.Active := false;
    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add
      ('SELECT monthcommunalpayments.id, monthcommunalpayments.datePayments, '
      +'namepayments.name, monthcommunalpayments.numberPayments, '
      +'monthcommunalpayments.fullName, monthcommunalpayments.adress, monthcommunalpayments.sum '
      +'FROM monthcommunalpayments '
      +'INNER JOIN namepayments ON monthcommunalpayments.namePayments=namepayments.id;');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
    ShowMessage('������ ������� ��������.');
  end;

procedure TForm1.Button3Click(Sender: TObject);
  Var bufName, bufId : string;
begin
    bufId := DBEdit1.Text;
    DBEdit1.DataField := '';

    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add('DELETE FROM monthcommunalpayments WHERE id = ' + bufId);
    SQLQuery1.ExecSQL;

    ClientDataSet1.Active := false;
    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add
      ('SELECT monthcommunalpayments.id, monthcommunalpayments.datePayments, '
      +'namepayments.name, monthcommunalpayments.numberPayments, '
      +'monthcommunalpayments.fullName, monthcommunalpayments.adress, monthcommunalpayments.sum '
      +'FROM monthcommunalpayments '
      +'INNER JOIN namepayments ON monthcommunalpayments.namePayments=namepayments.id;');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
    ShowMessage('������ ������� �������.');
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
    DBGrid1.DataSource.DataSet.Locate('fullName', VarArrayOf([edit5.Text]),
    [loCaseInsensitive, loPartialKey]);
end;

procedure TForm1.Button5Click(Sender: TObject);
begin
    if VarType(SQLQuery1.Lookup('adress', Edit4.Text, 'sum')) <> VarNull then
      ShowMessage(VarToStr(SQLQuery1.Lookup('adress', Edit4.Text, 'sum')))
    else
      ShowMessage('��� ������');
  end;

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
    sheet.cells[1, 1] := '�����';
    sheet.cells[1, 2] := '����� ������';
    sheet.cells[1, 3] := '�������';
    sheet.cells[1, 4] := '�������';
    sheet.Columns[1].ColumnWidth := 20;
    sheet.Columns[2].ColumnWidth := 20;
    sheet.Columns[3].ColumnWidth := 20;
    sheet.Columns[4].ColumnWidth := 20;
    sheet.Columns[5].ColumnWidth := 20;

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
    ClientDataSet1.Active := false;
    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add
      ('SELECT monthcommunalpayments.id, monthcommunalpayments.datePayments, '
      +'namepayments.name, monthcommunalpayments.numberPayments, '
      +'monthcommunalpayments.fullName, monthcommunalpayments.adress, monthcommunalpayments.sum '
      +'FROM monthcommunalpayments '
      +'INNER JOIN namepayments ON monthcommunalpayments.namePayments=namepayments.id;');
      SQLQuery1.Open;
    ClientDataSet1.Active := true;

    ClientDataSet3.Active := false;
    SQLQuery3.Close;
    SQLQuery3.SQL.Clear;
    SQLQuery3.SQL.Add
      ('SELECT monthcommunalpayments.id, monthcommunalpayments.datePayments, '
      +'namepayments.name, monthcommunalpayments.numberPayments, '
      +'monthcommunalpayments.fullName, monthcommunalpayments.adress, monthcommunalpayments.sum '
      +'FROM monthcommunalpayments '
      +'INNER JOIN namepayments ON monthcommunalpayments.namePayments=namepayments.id;');
      SQLQuery3.Open;
    ClientDataSet3.Active := true;
end;

procedure TForm1.Button8Click(Sender: TObject);
Var Od : TOpenDialog;
      exApp, exBook, exSh : OleVariant;
      FileName : string;
      i,j,index: Integer;
begin
  //������ ������ �����.
  Od := OpenDialog1; //OpenDialog1 ��� ������ ���� �� �����.
  if Od.InitialDir = '' then //� �������� ��������� �������� �����, � ������� ����� ����������� ���� ���������.
    Od.InitialDir := ExtractFilePath(ParamStr(0));
  if not Od.Execute then //������ ������ �����.
    Exit;
  if not FileExists(Od.FileName) then //�������� ������������� �����.
  begin
    MessageBox(Handle, '���� � �������� ������ �� ������! �������� ��������.',
      '��������!', MB_OK + MB_ICONEXCLAMATION + MB_APPLMODAL);
    Exit;
  end;

  //������ ���������� Excel � ��������� ������ �� ��������� ��������� ������� (Excel.Application).
  exApp := CreateOleObject('Excel.Application');
  //������ ������� ���� MS Excel. �� ����� ������� ��� �� ���������� ������.
  exApp.Visible := True;
  //��������� ���. ����� � �������� ������ �� � ���������.
  exBook := exApp.Workbooks.Open(FileName:=Od.FileName);
  //������ �� ��������� ������� ����� ������� �����.
  exSh := exBook.Worksheets[1];

    index := 2;
    exSh.cells[2, 1].Value := 'Date';
    exSh.cells[2, 2].Value := 'Name';
    exSh.cells[2, 3].Value := 'Number';
    exSh.cells[2, 4].Value := 'Fullname';
    exSh.cells[2, 5].Value := 'Adress';
    exSh.cells[2, 6].Value := 'Sum';
    exSh.Columns[1].ColumnWidth := 20;
    exSh.Columns[2].ColumnWidth := 20;
    exSh.Columns[3].ColumnWidth := 20;
    exSh.Columns[4].ColumnWidth := 10;
    //sheet.Columns[5].ColumnWidth := 10;

    DBGrid1.DataSource.DataSet.First;
    for i := 1 to DBGrid1.DataSource.DataSet.RecordCount do
    begin
      for j := 1 to DBGrid1.FieldCount do
        exSh.cells[index, j].Value := DBGrid1.fields[j - 1].asstring;
      inc(index);
      DBGrid1.DataSource.DataSet.Next;
    end;

  //exBook.Close; //��������� ������� �����.
  //exApp.Quit;   //��������� MS Excel
end;

procedure TForm1.DataSource1DataChange(Sender: TObject; Field: TField);
begin
    DateTimePicker1.DateTime := StrToDateTime(DBGrid1.Fields[1].AsString);
    Edit1.Text := DBGrid1.Fields[3].AsString;
    Edit2.Text := DBGrid1.Fields[4].AsString;
    Edit3.Text := DBGrid1.Fields[5].AsString;
    Edit7.Text := DBGrid1.Fields[6].AsString;
end;

procedure TForm1.Edit6KeyPress(Sender: TObject; var Key: Char);
begin
    ClientDataSet1.Active := false;
    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add
      ('SELECT monthcommunalpayments.id, monthcommunalpayments.datePayments, '
      +'namepayments.name, monthcommunalpayments.numberPayments, '
      +'monthcommunalpayments.fullName, monthcommunalpayments.adress, monthcommunalpayments.sum '
      +'FROM monthcommunalpayments '
      +'INNER JOIN namepayments ON monthcommunalpayments.namePayments=namepayments.id '
      +'WHERE numberPayments LIKE "%' + edit6.Text + '%"');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
end;

end.
