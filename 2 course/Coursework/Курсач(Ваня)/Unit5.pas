unit Unit5;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.DBXMySQL, Data.FMTBcd,
  Vcl.StdCtrls, Vcl.DBCtrls, Datasnap.DBClient, Datasnap.Provider, Data.DB,
  Data.SqlExpr, Vcl.Mask;

type
  TForm5 = class(TForm)
    SQLConnection1: TSQLConnection;
    SQLQuery1: TSQLQuery;
    DataSource1: TDataSource;
    DataSetProvider1: TDataSetProvider;
    ClientDataSet1: TClientDataSet;
    Button1: TButton;
    Memo1: TMemo;
    DBEdit1: TDBEdit;
    SQLConnection2: TSQLConnection;
    SQLQuery2: TSQLQuery;
    DataSetProvider2: TDataSetProvider;
    ClientDataSet2: TClientDataSet;
    DataSource2: TDataSource;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form5: TForm5;

implementation

{$R *.dfm}

uses Unit1;

procedure TForm5.Button1Click(Sender: TObject);
Var i: integer;
begin
  if button1.Caption = '��������' then
  begin
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add('INSERT INTO paragraf(��������) VALUES("');
    for I := 0 to Memo1.Lines.Count do
      SQLQuery1.SQL.Add(Memo1.Lines[i]);
    SQLQuery1.SQL.Add('")');
    SQLQuery1.ExecSQL;
    exit;
  end;
  if button1.Caption = '��������' then
  begin
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add('UPDATE paragraf SET �������� = "');
    for I := 0 to Memo1.Lines.Count do
      SQLQuery1.SQL.Add(Memo1.Lines[i]);
    SQLQuery1.SQL.Add('" WHERE ID = ' + dbedit1.Text);
    SQLQuery1.ExecSQL;
    exit;
  end;
  if button1.Caption = '�������' then
  begin
    SQLQuery1.SQL.Clear;
    SQLQuery1.SQL.Add('DELETE FROM paragraf WHERE ID = ' + dbedit1.Text);
    SQLQuery1.ExecSQL;
    exit;
  end;
end;

end.
