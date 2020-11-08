unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.DBXMySQL, Data.FMTBcd, Data.DB,
  Vcl.Grids, Vcl.DBGrids, Datasnap.Provider, Datasnap.DBClient, Data.SqlExpr, ShellAPI,
  Vcl.StdCtrls, Vcl.DBCtrls;

type
  TFormProg = class(TForm)
    SQLConnection1: TSQLConnection;
    SQLQuery1: TSQLQuery;
    DataSource1: TDataSource;
    ClientDataSet1: TClientDataSet;
    DataSetProvider1: TDataSetProvider;
    DBGrid1: TDBGrid;
    DBMemo1: TDBMemo;
    Helper: TButton;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    procedure Button1Click(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure Button2Click(Sender: TObject);
    procedure HelperClick(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FormProg: TFormProg;

implementation

{$R *.dfm}

uses Unit3, Unit10, Unit2, Unit7, Unit8;
procedure TFormProg.Button1Click(Sender: TObject);
begin
  FormProg.Hide;
  Form3.Show;
  Form3.PageControl1.ActivePageIndex := 0;
end;

procedure TFormProg.Button2Click(Sender: TObject);
begin
  Form2.Show;
end;

procedure TFormProg.Button3Click(Sender: TObject);
begin
  Form8.Show;
end;

procedure TFormProg.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  Form10.Close;
end;

procedure TFormProg.HelperClick(Sender: TObject);
begin
  FormHelp.Show;
end;

end.
