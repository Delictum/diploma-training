unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.DB, Data.DBXMySQL, Data.FMTBcd,
  Datasnap.Provider, Datasnap.DBClient, Data.SqlExpr, Vcl.Grids, Vcl.DBGrids,
  Vcl.StdCtrls, Vcl.Mask, Vcl.DBCtrls, Vcl.ComCtrls, ExcelXP, ComObj,
  Vcl.ExtCtrls, VclTee.TeeGDIPlus, VCLTee.TeEngine, VCLTee.Series,
  VCLTee.TeeProcs, VCLTee.Chart, VCLTee.DBChart, mySQLDbTables,
  Datasnap.Win.MConnect, Datasnap.Win.SConnect, Data.Win.ADODB,
  FireDAC.Stan.Intf, FireDAC.Stan.Option, FireDAC.Stan.Error, FireDAC.UI.Intf,
  FireDAC.Phys.Intf, FireDAC.Stan.Def, FireDAC.Stan.Pool, FireDAC.Stan.Async,
  FireDAC.Phys, FireDAC.Phys.MySQL, FireDAC.Phys.MySQLDef, FireDAC.VCLUI.Wait,
  FireDAC.Stan.Param, FireDAC.DatS, FireDAC.DApt.Intf, FireDAC.DApt,
  FireDAC.Comp.DataSet, FireDAC.Comp.Client, FireDAC.Phys.ODBCBase,
  FireDAC.Phys.MSAcc;

type
  TForm1 = class(TForm)
    SQLConnection1: TSQLConnection;
    DBGrid1: TDBGrid;
    SQLQuery2: TSQLQuery;
    DataSetProvider2: TDataSetProvider;
    ClientDataSet2: TClientDataSet;
    DataSource2: TDataSource;
    DBLookupComboBox1: TDBLookupComboBox;
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
    Label1: TLabel;
    Edit5: TEdit;
    DBLookupListBox1: TDBLookupListBox;
    Label2: TLabel;
    Edit6: TEdit;
    DBGrid2: TDBGrid;
    Panel1: TPanel;
    DBNavigator1: TDBNavigator;
    Button7: TButton;
    Button8: TButton;
    OpenDialog1: TOpenDialog;
    SQLQuery1: TSQLQuery;
    ClientDataSet1: TClientDataSet;
    DataSetProvider1: TDataSetProvider;
    DataSource1: TDataSource;
    DataSource3: TDataSource;
    ClientDataSet3: TClientDataSet;
    DataSetProvider3: TDataSetProvider;
    SQLQuery3: TSQLQuery;
    DBChart1: TDBChart;
    Series1: TBarSeries;
    MySQLDatabase1: TMySQLDatabase;
    MySQLQuery1: TMySQLQuery;
    DataSource4: TDataSource;
    DBGrid3: TDBGrid;
    ADOConnection1: TADOConnection;
    ADOQuery1: TADOQuery;
    DataSource5: TDataSource;
    FDConnection1: TFDConnection;
    FDQuery1: TFDQuery;
    DataSource6: TDataSource;
    DBGrid4: TDBGrid;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Edit6KeyPress(Sender: TObject; var Key: Char);
    procedure DataSource1DataChange(Sender: TObject; Field: TField);
    procedure Button7Click(Sender: TObject);
    procedure Button8Click(Sender: TObject);
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
    case MessageDlg('�� �������, ��� ������ �������� ������?', mtConfirmation, [mbOK, mbCancel], 0) of
      mrOk:
        begin

        end;
      mrCancel:
        begin
          Exit;
        end;
    end;

    DBEdit1.DataField := '';
    DataSource1.OnDataChange := DataSource2.OnDataChange;

    ClientDataSet1.Active := false;
    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add('SELECT cityId FROM City WHERE cityName = "' + DBLookupComboBox1.Text + '"');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
    bufName := VarToStr(SQLQuery1.FieldValues['cityId']);

    ClientDataSet1.Active := false;
    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add('SELECT MAX(exchangeOfficeId) AS ID FROM exchangeoffice');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
    bufId := SQLQuery1.FieldValues['ID'] + 1;

    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add
      ('INSERT INTO ExchangeOffice(exchangeOfficeId, exchangeOfficeCityId, exchangeOfficeExchangeRate, '
      +'exchangeOfficeBuy, exchangeOfficeSale) VALUES (');
    SQLQuery1.SQL.Add(IntToStr(bufId) + ', ' + bufName + ', "' + Edit1.Text +
      '", ' + Edit2.Text + ', ' + Edit3.Text + ')');
    SQLQuery1.ExecSQL;

    ClientDataSet1.Active := false;
    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add
      ('SELECT cityName, exchangeOfficeExchangeRate, exchangeOfficeBuy, ' +
       'exchangeOfficeSale, exchangeOfficeId FROM exchangeoffice, city WHERE exchangeOfficeCityId = CityId');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
    DBEdit1.DataField := 'exchangeOfficeId';
    DataSource1.OnDataChange := DataSource1DataChange;
    ShowMessage('������ ������� ���������.');
  end;

procedure TForm1.Button2Click(Sender: TObject);
  Var bufName, bufId : string;
begin
    case MessageDlg('�� �������, ��� ������ �������� ������?', mtConfirmation, [mbOK, mbCancel], 0) of
      mrOk:
        begin

        end;
      mrCancel:
        begin
          Exit;
        end;
    end;

    bufId := DBEdit1.Text;
    DBEdit1.DataField := '';
    DataSource1.OnDataChange := DataSource2.OnDataChange;

    ClientDataSet1.Active := false;
    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add('SELECT cityId FROM City WHERE cityName = "' +
      DBLookupComboBox1.Text + '"');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
    bufName := VarToStr(SQLQuery1.FieldValues['cityId']);

    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add('UPDATE exchangeOffice Set exchangeOfficeCityId = ' +
      bufName + ', exchangeOfficeExchangeRate = "' + Edit1.Text +
      '", exchangeOfficeBuy = ' + Edit2.Text + ', exchangeOfficeSale = ' +
      Edit3.Text + ' WHERE exchangeOfficeId = ' + bufId);
    SQLQuery1.ExecSQL;

    ClientDataSet1.Active := false;
    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add
      ('SELECT cityName, exchangeOfficeExchangeRate, exchangeOfficeBuy, ' +
      'exchangeOfficeSale, exchangeOfficeId FROM exchangeoffice, city WHERE exchangeOfficeCityId = CityId');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
    DBEdit1.DataField := 'exchangeOfficeId';
    DataSource1.OnDataChange := DataSource1DataChange;
    ShowMessage('������ ������� ��������.');
  end;

procedure TForm1.Button3Click(Sender: TObject);
  Var bufName, bufId : string;
begin
    case MessageDlg('�� �������, ��� ������ ������� ������?', mtConfirmation, [mbOK, mbCancel], 0) of
      mrOk:
        begin

        end;
      mrCancel:
        begin
          Exit;
        end;
    end;

    bufId := DBEdit1.Text;
    DBEdit1.DataField := '';
    DataSource1.OnDataChange := DataSource2.OnDataChange;

    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add('DELETE FROM exchangeoffice WHERE exchangeOfficeId = ' + bufId);
    SQLQuery1.ExecSQL;

    ClientDataSet1.Active := false;
    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add
      ('SELECT cityName, exchangeOfficeExchangeRate, exchangeOfficeBuy, ' +
      'exchangeOfficeSale, exchangeOfficeId FROM exchangeoffice, city WHERE exchangeOfficeCityId = CityId');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
    DBEdit1.DataField := 'exchangeOfficeId';
    DataSource1.OnDataChange := DataSource1DataChange;
    ShowMessage('������ ������� �������.');
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
    DBGrid1.DataSource.DataSet.Locate('exchangeOfficeExchangeRate', VarArrayOf([edit5.Text]),
    [loCaseInsensitive, loPartialKey]);
end;

procedure TForm1.Button5Click(Sender: TObject);
begin
    if VarType(SQLQuery1.Lookup('exchangeOfficeExchangeRate', Edit4.Text, 'exchangeOfficeBuy')) <> VarNull then
      ShowMessage('�������: ' +
        VarToStr(SQLQuery1.Lookup('exchangeOfficeExchangeRate', Edit4.Text,
        'exchangeOfficeBuy')) + ', �������: ' +
        VarToStr(SQLQuery1.Lookup('exchangeOfficeExchangeRate', Edit4.Text,
        'exchangeOfficeSale')))
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
    sheet.Columns[4].ColumnWidth := 10;
    //sheet.Columns[5].ColumnWidth := 10;

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
      ('SELECT cityName, exchangeOfficeExchangeRate, exchangeOfficeBuy, ' +
      'exchangeOfficeSale, exchangeOfficeId FROM exchangeoffice, city WHERE exchangeOfficeCityId = CityId');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;

    ClientDataSet3.Active := false;
    SQLQuery3.Close;
    SQLQuery3.SQL.Clear;
    SQLQuery3.SQL.Add
      ('SELECT exchangeOfficeExchangeRate, exchangeOfficeBuy, ' +
       'exchangeOfficeId FROM exchangeoffice');
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
    exSh.cells[2, 1].Value := '�����';
    exSh.cells[2, 2].Value := '����� ������';
    exSh.cells[2, 3].Value := '�������';
    exSh.cells[2, 4].Value := '�������';
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
    Edit1.Text := DBGrid1.Fields[1].AsString;
    Edit2.Text := DBGrid1.Fields[2].AsString;
    Edit3.Text := DBGrid1.Fields[3].AsString;
end;

procedure TForm1.Edit6KeyPress(Sender: TObject; var Key: Char);
begin
    ClientDataSet1.Active := false;
    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add
      ('SELECT cityName, exchangeOfficeExchangeRate, exchangeOfficeBuy, ' +
      'exchangeOfficeSale, exchangeOfficeId FROM exchangeoffice, city WHERE exchangeOfficeCityId = CityId ' +
      'AND cityName LIKE "%' + edit6.Text + '%"');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
end;

end.
