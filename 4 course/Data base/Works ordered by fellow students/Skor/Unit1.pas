unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.DB, Data.DBXMySQL, Data.FMTBcd,
  Datasnap.Provider, Datasnap.DBClient, Data.SqlExpr, Vcl.Grids, Vcl.DBGrids,
  Vcl.StdCtrls, Vcl.Mask, Vcl.DBCtrls, Vcl.ComCtrls, ExcelXP, ComObj,
  Vcl.ExtCtrls, VclTee.TeeGDIPlus, VCLTee.TeEngine, VCLTee.Series,
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
    DBLookupComboBox1: TDBLookupComboBox;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    DBEdit1: TDBEdit;
    Button4: TButton;
    Button5: TButton;
    Edit4: TEdit;
    Edit5: TEdit;
    DBLookupListBox1: TDBLookupListBox;
    Label2: TLabel;
    Edit6: TEdit;
    DBGrid2: TDBGrid;
    Panel1: TPanel;
    DBNavigator1: TDBNavigator;
    Button7: TButton;
    OpenDialog1: TOpenDialog;
    DBLookupComboBox2: TDBLookupComboBox;
    SQLQuery3: TSQLQuery;
    DataSetProvider3: TDataSetProvider;
    ClientDataSet3: TClientDataSet;
    DataSource3: TDataSource;
    DateTimePicker1: TDateTimePicker;
    Button6: TButton;
    DBChart1: TDBChart;
    ClientDataSet4: TClientDataSet;
    SQLQuery4: TSQLQuery;
    DataSetProvider4: TDataSetProvider;
    DataSource4: TDataSource;
    Series1: TLineSeries;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Edit6KeyPress(Sender: TObject; var Key: Char);
    procedure DataSource1DataChange(Sender: TObject; Field: TField);
    procedure Button7Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
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
    SQLQuery1.SQL.Add('SELECT id_vlad FROM vladelectelefona WHERE Familiya = "' + DBLookupComboBox1.Text + '"');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
    bufName := VarToStr(SQLQuery1.FieldValues['id_vlad']);

    ClientDataSet1.Active := false;
    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add('SELECT MAX(id_kvit) AS ID FROM kvitancia');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
    bufId := SQLQuery1.FieldValues['ID'] + 1;

    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add
      ('INSERT INTO kvitancia(id_kvit, id_vladelec, id_norma, '
      +'dataoplati) VALUES (');
    SQLQuery1.SQL.Add(IntToStr(bufId) + ', ' + bufName + ', ' + DBLookupComboBox2.Text + ', "' +
    ParseDate(DateTimeToStr(DateTimePicker1.DateTime)) + '")');
    SQLQuery1.ExecSQL;

    ClientDataSet1.Active := false;
    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add
      ('SELECT id_kvit, Familiya, Name, Otchestvo, Telefon, DomAdres, APYS, MTR, abonentplata, dataoplati FROM normi, vladelectelefona, kvitancia WHERE ' +
       'kvitancia.id_vladelec = vladelectelefona.id_vlad AND kvitancia.id_norma = normi.id_norm');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
    DBEdit1.DataField := 'id_kvit';
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
    SQLQuery1.SQL.Add('SELECT id_vlad FROM vladelectelefona WHERE Familiya = "' + DBLookupComboBox1.Text + '"');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
    bufName := VarToStr(SQLQuery1.FieldValues['id_vlad']);

    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add('UPDATE kvitancia Set id_vladelec = ' +
      bufName + ', id_norma = ' + DBLookupComboBox2.Text + ', dataoplati = "' + ParseDate(DateTimeToStr(DateTimePicker1.DateTime)) +
      '" WHERE id_kvit = ' + bufId);
    SQLQuery1.ExecSQL;

    ClientDataSet1.Active := false;
    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add
      ('SELECT id_kvit, Familiya, Name, Otchestvo, Telefon, DomAdres, APYS, MTR, abonentplata, dataoplati FROM normi, vladelectelefona, kvitancia WHERE ' +
       'kvitancia.id_vladelec = vladelectelefona.id_vlad AND kvitancia.id_norma = normi.id_norm');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
    DBEdit1.DataField := 'id_kvit';
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
    SQLQuery1.SQL.Add('DELETE FROM kvitancia WHERE id_kvit = ' + bufId);
    SQLQuery1.ExecSQL;

    ClientDataSet1.Active := false;
    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add
      ('SELECT id_kvit, Familiya, Name, Otchestvo, Telefon, DomAdres, APYS, MTR, abonentplata, dataoplati FROM normi, vladelectelefona, kvitancia WHERE ' +
       'kvitancia.id_vladelec = vladelectelefona.id_vlad AND kvitancia.id_norma = normi.id_norm');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
    DBEdit1.DataField := 'id_kvit';
    DataSource1.OnDataChange := DataSource1DataChange;
    ShowMessage('������ ������� �������.');
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
    DBGrid1.DataSource.DataSet.Locate('Familiya', VarArrayOf([edit5.Text]),
    [loCaseInsensitive, loPartialKey]);
end;

procedure TForm1.Button5Click(Sender: TObject);
begin
    if VarType(SQLQuery1.Lookup('Familiya', Edit4.Text, 'APYS')) <> VarNull then
      ShowMessage('APYS: ' +
        VarToStr(SQLQuery1.Lookup('Familiya', Edit4.Text,
        'APYS')) + ', MTR: ' +
        VarToStr(SQLQuery1.Lookup('Familiya', Edit4.Text,
        'MTR')))
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
    sheet.cells[1, 1] := '���';
    sheet.cells[1, 2] := '�������';
    sheet.cells[1, 3] := '���';
    sheet.cells[1, 4] := '��������';
    sheet.cells[1, 5] := '�������';
    sheet.cells[1, 6] := '�������� �����';
    sheet.cells[1, 7] := '��������';
    sheet.cells[1, 8] := '���';
    sheet.cells[1, 9] := '����������� �����';
    sheet.cells[1, 10] := '���� ������';
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
      ('SELECT id_kvit, Familiya, Name, Otchestvo, Telefon, DomAdres, APYS, MTR, abonentplata, dataoplati FROM normi, vladelectelefona, kvitancia WHERE ' +
       'kvitancia.id_vladelec = vladelectelefona.id_vlad AND kvitancia.id_norma = normi.id_norm');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;

    ClientDataSet4.Active := false;
    SQLQuery4.Close;
    SQLQuery4.SQL.Clear;
    SQLQuery4.SQL.Add
      ('SELECT id_kvit, Familiya, Name, Otchestvo, Telefon, DomAdres, APYS, MTR, abonentplata, dataoplati FROM normi, vladelectelefona, kvitancia WHERE ' +
       'kvitancia.id_vladelec = vladelectelefona.id_vlad AND kvitancia.id_norma = normi.id_norm');
    SQLQuery4.Open;
    ClientDataSet4.Active := true;
end;



procedure TForm1.DataSource1DataChange(Sender: TObject; Field: TField);
begin
    DateTimePicker1.DateTime := StrToDateTime(DBGrid1.Fields[9].AsString);
end;

procedure TForm1.Edit6KeyPress(Sender: TObject; var Key: Char);
begin
    ClientDataSet1.Active := false;
    SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add
      ('SELECT id_kvit, Familiya, Name, Otchestvo, Telefon, DomAdres, APYS, MTR, abonentplata, dataoplati FROM normi, vladelectelefona, kvitancia WHERE ' +
       'kvitancia.id_vladelec = vladelectelefona.id_vlad AND kvitancia.id_norma = normi.id_norm ' +
       'AND Familiya LIKE "%' + edit6.Text + '%"');
    SQLQuery1.Open;
    ClientDataSet1.Active := true;
end;

end.
