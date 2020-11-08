unit Unit7;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.FMTBcd, Data.DBXMySQL, Data.DB,
  Vcl.StdCtrls, Vcl.Mask, Vcl.DBCtrls, Vcl.Grids, Vcl.DBGrids,
  Datasnap.Provider, Datasnap.DBClient, Data.SqlExpr;

type
  TFormADMIN = class(TForm)
    SQLQuery1: TSQLQuery;
    SQLConnection1: TSQLConnection;
    ClientDataSet1: TClientDataSet;
    DataSetProvider1: TDataSetProvider;
    DataSource1: TDataSource;
    DBGrid1: TDBGrid;
    Button1: TButton;
    DBEdit1: TDBEdit;
    SQLQuery2: TSQLQuery;
    ClientDataSet2: TClientDataSet;
    DataSetProvider2: TDataSetProvider;
    DataSource2: TDataSource;
    Button2: TButton;
    EditPasLog: TEdit;
    EditNameLog: TEdit;
    Button3: TButton;
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FormADMIN: TFormADMIN;

implementation

{$R *.dfm}

uses Unit4, Unit1, Unit3;

procedure TFormADMIN.Button1Click(Sender: TObject);
begin
  SQLQuery2.Close;
  SQLQuery2.SQL.Clear;
  SQLQuery2.SQL.Add('DELETE FROM Users WHERE ID = ' + DBEdit1.Text);
  SQLQuery2.ExecSQL;
  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT *  FROM Users WHERE Name <> "Admin"');
  SQLQuery1.Open;
  ClientDataSet1.Active := true;
  DBGrid1.Refresh;
  ShowMessage('Пользователь успешно удален.');
end;

procedure TFormADMIN.Button2Click(Sender: TObject);
begin
  if (EditNameLog.Text = '') or (EditNameLog.Text = 'Введите пользователя') then
  begin
    ShowMessage('Введите новое имя пользователя.');
    exit;
  end;
  if (EditPasLog.Text = '') or (EditPasLog.Text = 'Введите пароль') then
  begin
    ShowMessage('Введите новый пароль пользователя.');
    exit;
  end;
  SQLQuery2.Close;
  SQLQuery2.SQL.Clear;
  SQLQuery2.SQL.Add('UPDATE Users Set Name = "' + EditNameLog.Text + '", Password = "' + EditPasLog.Text + '" ');
  SQLQuery2.SQL.Add('WHERE ID = ' + DBEdit1.Text);
  SQLQuery2.ExecSQL;
  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT *  FROM Users WHERE Name <> "Admin"');
  SQLQuery1.Open;
  ClientDataSet1.Active := true;
  DBGrid1.Refresh;
  ShowMessage('Пользователь успешно удален.');
end;

procedure TFormADMIN.Button3Click(Sender: TObject);
begin
  FormAdmin.Hide;
  FormBegin.Show;
end;

procedure TFormADMIN.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  LogOut.Close;
end;

end.
