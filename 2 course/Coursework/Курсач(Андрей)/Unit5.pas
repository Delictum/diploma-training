unit Unit5;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Data.FMTBcd, DBXMySQL,
  Data.DB, Vcl.Grids, Vcl.DBGrids, Data.SqlExpr, Datasnap.Provider,
  Datasnap.DBClient, Vcl.Imaging.jpeg, Vcl.ExtCtrls, Vcl.Menus, ShellAPI,
  Vcl.Imaging.pngimage;

type
  TFormEnd = class(TForm)
    DataSource1: TDataSource;
    ClientDataSet1: TClientDataSet;
    DataSetProvider1: TDataSetProvider;
    SQLQuery1: TSQLQuery;
    SQLConnection1: TSQLConnection;
    DBGrid1: TDBGrid;
    LabelTable: TLabel;
    LabelNewScore: TLabel;
    Image1: TImage;
    MainMenu1: TMainMenu;
    N1: TMenuItem;
    N4: TMenuItem;
    Helper1: TMenuItem;
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure ImgRestartClick(Sender: TObject);
    procedure N2Click(Sender: TObject);
    procedure Helper1Click(Sender: TObject);
    procedure N3Click(Sender: TObject);
    procedure N4Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FormEnd: TFormEnd;

implementation

{$R *.dfm}

uses Unit1, Unit4, Unit3, Unit2, Unit8;

procedure TFormEnd.FormClose(Sender: TObject; var Action: TCloseAction);
  Var i : integer;
begin
  for i := 1 to 10 do
    if FileExists('music\' + IntToStr(i) +'.mp3') then
      DeleteFile('music\' + IntToStr(i) +'.mp3');
  FormBegin.Close;
  FormGame.Close;
  LogOut.Close;
end;

procedure TFormEnd.Helper1Click(Sender: TObject);
begin
  FormHelp.Show;
end;

procedure TFormEnd.ImgRestartClick(Sender: TObject);
begin

  GameScore := 0;
  FormEnd.Hide;
  FormBegin.Show;
end;

procedure TFormEnd.N2Click(Sender: TObject);
  Var i : integer;
begin
  FormGame.MediaPlayer1.Stop;
  FormGame.MediaPlayer1.Position:=0;
  GameNumberStep := 0;
  for i := 1 to 10 do
    if FileExists('music\' + IntToStr(i) +'.mp3') then
      DeleteFile('music\' + IntToStr(i) +'.mp3');
  FormGame.Hide;
  LogOut.Show;
  Admin := 0;
end;

procedure TFormEnd.N3Click(Sender: TObject);
  Var i : integer;
begin
  GameNumberStep := 0;
  FormGame.MediaPlayer1.Stop;
  FormGame.MediaPlayer1.Position:=0;
  for i := 1 to 10 do
    if FileExists('music\' + IntToStr(i) +'.mp3') then
      DeleteFile('music\' + IntToStr(i) +'.mp3');
  GameStepIDName := 1;
  GameStepIDBoolean := false;
  GameStepIDPlay := 1;
  GameStepID := 1;
  GameScore := 0;
  FormGame.Image7Click(Self);
  FormBegin.ProgressBar1.Position := 0;
  FormEnd.Hide;
  FormBegin.Show;
end;

procedure TFormEnd.N4Click(Sender: TObject);
  Var i : integer;
begin
  for i := 1 to 10 do
    if FileExists('music\' + IntToStr(i) +'.mp3') then
      DeleteFile('music\' + IntToStr(i) +'.mp3');
  LogOut.Close;
  FormBegin.Close;
  FormGame.Close;
  FormEnd.Close;
end;

end.
