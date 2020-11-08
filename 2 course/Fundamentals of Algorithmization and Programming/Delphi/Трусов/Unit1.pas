unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.DB, Vcl.StdCtrls, Vcl.Grids, ComObj,
  Vcl.DBGrids, Data.Win.ADODB, Vcl.DBCtrls, DBXMySQL, Data.FMTBcd,
  Datasnap.Provider, Datasnap.DBClient, Data.SqlExpr;

type
  TForm1 = class(TForm)
    DBGrid1: TDBGrid;
    ComboBox2: TComboBox;
    SQLConnection1: TSQLConnection;
    SQLQuery1: TSQLQuery;
    DataSetProvider1: TDataSetProvider;
    ComboBox1: TComboBox;
    ClientDataSet1: TClientDataSet;
    DataSource1: TDataSource;
    Edit1: TEdit;
    Button1: TButton;
    Button4: TButton;
    procedure Button4Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure ComboBox1Change(Sender: TObject);
    procedure ComboBox2Change(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  i,j,index, buf: Integer;
ExcelApp,sheet: Variant;

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
begin
  with SQLQuery1 do
        begin
          ClientDataSet1.Active := false;
          Close;
          SQL.Clear;
          SQL.Add('SELECT AVG(Ocenka) AS ID FROM Stud');
          Open;
          ClientDataSet1.Active := true;
        end;
  Edit1.Text := VarToStr(SQLQuery1.FieldValues['ID']);
  buf := Trunc(SQLQuery1.FieldValues['ID']);

  with SQLQuery1 do
        begin
          ClientDataSet1.Active := false;
          Close;
          SQL.Clear;
          SQL.Add('SELECT * FROM Stud WHERE Ocenka > ' + IntToStr(buf) + ' ORDER BY Ocenka DESC');
          Open;
          ClientDataSet1.Active := true;
        end;
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
  ExcelApp := CreateOleObject('Excel.Application');
ExcelApp.Visible := False;
ExcelApp.WorkBooks.Add(-4167);
ExcelApp.WorkBooks[1].WorkSheets[1].name := 'Export';
sheet:=ExcelApp.WorkBooks[1].WorkSheets['Export'];
index:=1;
DBGrid1.DataSource.DataSet.First;
for i:=1 to DBGrid1.DataSource.DataSet.RecordCount do
begin
for j:=1 to DBGrid1.FieldCount do
sheet.cells[index,j]:=DBGrid1.fields[j-1].asstring;
inc(index);
DBGrid1.DataSource.DataSet.Next;
end;
ExcelApp.Visible := true;
  ExcelApp.WorkBooks[1].SaveAs('c:\Air.xls');
 ExcelApp := UnAssigned;
end;

procedure TForm1.ComboBox1Change(Sender: TObject);
begin
  case ComboBox1.ItemIndex of
    0:
    begin
      with SQLQuery1 do
        begin
          ClientDataSet1.Active := false;
          Close;
          SQL.Clear;
          SQL.Add('SELECT * FROM Stud ORDER BY Fam');
          Open;
          ClientDataSet1.Active := true;
        end;
    end;
    1:
    begin
      with SQLQuery1 do
        begin
          ClientDataSet1.Active := false;
          Close;
          Sql.Clear;
          Sql.Add('SELECT * FROM Stud ORDER BY Ocenka');
          Open;
          ClientDataSet1.Active := true;
        end;
    end;
  end;
end;

procedure TForm1.ComboBox2Change(Sender: TObject);
begin
  case ComboBox2.ItemIndex of
    0:
    begin
      with SQLQuery1 do
        begin
          ClientDataSet1.Active := false;
          Close;
          SQL.Clear;
          SQL.Add('SELECT * FROM Stud ORDER BY Fam DESC');
          Open;
          ClientDataSet1.Active := true;
        end;
    end;
    1:
    begin
      with SQLQuery1 do
        begin
          ClientDataSet1.Active := false;
          Close;
          Sql.Clear;
          Sql.Add('SELECT * FROM Stud ORDER BY Ocenka DESC');
          Open;
          ClientDataSet1.Active := true;
        end;
    end;
  end;
end;

end.
