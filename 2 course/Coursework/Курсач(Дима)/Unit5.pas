unit Unit5;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.FMTBcd, Data.DBXMySQL, Data.DB,
  Vcl.StdCtrls, Vcl.Mask, Vcl.DBCtrls, Vcl.Grids, Vcl.DBGrids,
  Datasnap.Provider, Datasnap.DBClient, Data.SqlExpr;

type
  TForm5 = class(TForm)
    SQLQuery1: TSQLQuery;
    SQLConnection1: TSQLConnection;
    ClientDataSet1: TClientDataSet;
    DataSetProvider1: TDataSetProvider;
    DataSource1: TDataSource;
    DBGrid1: TDBGrid;
    Button1: TButton;
    DBEdit1: TDBEdit;
    SQLConnection2: TSQLConnection;
    SQLQuery2: TSQLQuery;
    ClientDataSet2: TClientDataSet;
    DataSetProvider2: TDataSetProvider;
    DataSource2: TDataSource;
    Button2: TButton;
    EditPasLog: TEdit;
    EditNameLog: TEdit;
    Button3: TButton;
    Label1: TLabel;
    Label2: TLabel;
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
  Form5: TForm5;

implementation

{$R *.dfm}

uses Unit4, Unit1;

procedure TForm5.Button1Click(Sender: TObject);
begin
  SQLQuery2.Close;
  SQLQuery2.SQL.Clear;
  SQLQuery2.SQL.Add('DELETE FROM Users WHERE ID = ' + DBEdit1.Text);
  SQLQuery2.ExecSQL;
  ClientDataSet1.Active := false;
  SQLQuery1.Close;
  SQLQuery1.SQL.Clear;
  SQLQuery1.SQL.Add('SELECT * FROM Users WHERE ID > 1');
  SQLQuery1.Open;
  ClientDataSet1.Active := true;
  DBGrid1.Refresh;
  ShowMessage('Пользователь успешно удален.');
end;

procedure TForm5.Button2Click(Sender: TObject);
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
  SQLQuery1.SQL.Add('SELECT * FROM Users WHERE ID > 1');
  SQLQuery1.Open;
  ClientDataSet1.Active := true;
  DBGrid1.Refresh;
  ShowMessage('Пользователь успешно удален.');
end;

procedure TForm5.Button3Click(Sender: TObject);
begin
  Form5.Hide;
  FormProg.Show;
end;

procedure TForm5.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  Form4.Close;
end;

end.
