unit Unit9;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, DBXMySQL, Data.FMTBcd, Vcl.StdCtrls,
  Data.DB, Datasnap.DBClient, Datasnap.Provider, Data.SqlExpr, Vcl.Grids,
  Vcl.DBGrids;

type
  TFormEnd = class(TForm)
    SQLConnection1: TSQLConnection;
    SQLQuery1: TSQLQuery;
    DataSetProvider1: TDataSetProvider;
    ClientDataSet1: TClientDataSet;
    DataSource1: TDataSource;
    Label1: TLabel;
    Button1: TButton;
    DBGrid1: TDBGrid;
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure FormShow(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FormEnd: TFormEnd;

implementation

{$R *.dfm}

uses Unit6, Unit7, Unit8, Unit5, Unit2, Unit3;

procedure TFormEnd.Button1Click(Sender: TObject);
begin
  FormEnd.Hide;
  FormBegin.Show;
  Otvet := 0;

end;

procedure TFormEnd.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  FormGame1.Close;
  FormGame2.Close;
  FormGame3.Close;
  LogOut.Close;
  FormBegin.Close;
end;

procedure TFormEnd.FormShow(Sender: TObject);
begin
  FormEnd.Label1.Caption := '�� �������� ' + IntToStr(Otvet) + ' ������!';

  FormEnd.ClientDataSet1.Active := false;
  FormEnd.SQLQuery1.Close;
  FormEnd.SQLQuery1.SQL.Clear;
  FormEnd.SQLQuery1.SQL.Add('SELECT * FROM Users WHERE Name = "' + bufName + '"');
  FormEnd.SQLQuery1.Open;
  FormEnd.ClientDataSet1.Active := true;
  if IntToStr(Otvet) > VarToStr(FormEnd.SQLQuery1.FieldValues['Score']) then
  begin
    ShowMessage('�� ������ ���� ������!');
    FormEnd.SQLQuery1.Close;
    FormEnd.SQLQuery1.SQL.Clear;
    FormEnd.SQLQuery1.SQL.Add('UPDATE Users Set Score = ' + IntToStr(Otvet));
    FormEnd.SQLQuery1.SQL.Add(' WHERE Name = "' + bufName + '"');
    FormEnd.SQLQuery1.ExecSQL;
  end;
  FormEnd.ClientDataSet1.Active := false;
  FormEnd.SQLQuery1.Close;
  FormEnd.SQLQuery1.SQL.Clear;
  FormEnd.SQLQuery1.SQL.Add('SELECT * FROM Users ORDER BY  Score DESC LIMIT 5');
  FormEnd.SQLQuery1.Open;
  FormEnd.ClientDataSet1.Active := true;

  DBGrid1.Refresh;
end;

end.
