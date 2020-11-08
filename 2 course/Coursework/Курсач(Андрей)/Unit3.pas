unit Unit3;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.DBCtrls, Vcl.StdCtrls, Data.FMTBcd,
  DBXMySQL, Data.DB, Data.SqlExpr, Datasnap.Provider, Datasnap.DBClient, ShellAPI,
  Vcl.Imaging.pngimage, Vcl.Imaging.jpeg, Vcl.ExtCtrls, Vcl.ComCtrls, Vcl.Menus;

type
  TFormBegin = class(TForm)
    CBLevel: TComboBox;
    DBLCBGenre: TDBLookupComboBox;
    DataSource1: TDataSource;
    ClientDataSet1: TClientDataSet;
    DataSetProvider1: TDataSetProvider;
    SQLQuery1: TSQLQuery;
    SQLConnection1: TSQLConnection;
    StaticText1: TStaticText;
    Image1: TImage;
    ImageGo: TImage;
    Timer1: TTimer;
    ProgressBar1: TProgressBar;
    MainMenu1: TMainMenu;
    N1: TMenuItem;
    N4: TMenuItem;
    Helper1: TMenuItem;
    Button1: TButton;
    Button2: TButton;
    procedure CBLevelChange(Sender: TObject);
    procedure DBLCBGenreClick(Sender: TObject);
    procedure ImageGoClick(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure Helper1Click(Sender: TObject);
    procedure N4Click(Sender: TObject);
    procedure N2Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FormBegin: TFormBegin;
  GameStepIDName, GameStepIDPlay : integer;
  GameStepIDBoolean : Boolean;

implementation

{$R *.dfm}

uses Unit1, Unit4, Unit2, Unit6, Unit8;

procedure TFormBegin.Button1Click(Sender: TObject);
begin
  Form6.Show;
  Form6.ClientDataSet1.Active := false;
   Form6.SQLQuery1.Close;
    Form6.SQLQuery1.SQL.Clear;
     Form6.SQLQuery1.SQL.Add('SELECT * FROM Level WHERE ID = ' + IntToStr(CBLevel.ItemIndex + 1));
      Form6.SQLQuery1.Open;
       Form6.ClientDataSet1.Active := true;
end;

procedure TFormBegin.Button2Click(Sender: TObject);
begin
  Form6.Show;
  Form6.ClientDataSet1.Active := false;
   Form6.SQLQuery1.Close;
    Form6.SQLQuery1.SQL.Clear;
     Form6.SQLQuery1.SQL.Add('SELECT * FROM Level WHERE ID = ' + IntToStr(CBLevel.ItemIndex + 1));
      Form6.SQLQuery1.Open;
       Form6.ClientDataSet1.Active := true;
end;

procedure TFormBegin.CBLevelChange(Sender: TObject);  //��������� ������ ������
begin
  if CBLevel.ItemIndex > 1 then
    ShowMessage('������� � ����������.');
  ClientDataSet1.Active := false;
   SQLQuery1.Close;
    SQLQuery1.SQL.Clear;
     SQLQuery1.SQL.Add('SELECT Name_Genre FROM Genre WHERE ID_Level = ' + IntToStr(CBLevel.ItemIndex + 1));
      SQLQuery1.Open;
       ClientDataSet1.Active := true;
  StaticText1.Visible := true;
  DBLCBGenre.Visible := true;
  DBLCBGenre.Enabled := true;
end;

procedure TFormBegin.DBLCBGenreClick(Sender: TObject);
begin
  if DBLCBGenre.ListFieldIndex > 2 then
  begin
    ShowMessage('���� � ����������.');
    exit;
  end;
  StaticText1.Visible := false;
  ImageGo.Visible := true;
  ProgressBar1.Visible := true;
end;

procedure TFormBegin.FormClose(Sender: TObject; var Action: TCloseAction);
Var i : integer;
begin
  for i := 1 to 10 do
    if FileExists('music\' + IntToStr(i) +'.mp3') then
      DeleteFile('music\' + IntToStr(i) +'.mp3');
  LogOut.Close;
end;

procedure TFormBegin.FormShow(Sender: TObject);
begin
  if Admin = 1 then
  begin
    button1.Visible := true;
    button2.Visible := true;
  end;
  GameStepIDName := 1;                            //������� �������� ����� = 1
end;

procedure TFormBegin.Helper1Click(Sender: TObject);
begin
  FormHelp.Show;
end;

procedure TFormBegin.ImageGoClick(Sender: TObject);
Var bufIDRandom : string;
    MPWithMP: Tmemorystream;
begin
  if (DBLCBGenre.Text <> '') and (CBLevel.ItemIndex < 2) then
    begin
      if (GameStepIDBoolean <> true) and (DBLCBGenre.Text = '���') and (CBLevel.ItemIndex = 0) then
        begin
          GameStepID := 1;
          GameStepIDPlay := 1;
        end;
      if (GameStepIDBoolean <> true) and (DBLCBGenre.Text = '������������ ������') then
        begin
          GameStepID := 11;
          GameStepIDPlay := 11;
        end;
      if (GameStepIDBoolean <> true) and (DBLCBGenre.Text = '����') then
        begin
          GameStepID := 21;
          GameStepIDPlay := 21;
        end;
      if (GameStepIDBoolean <> true) and (DBLCBGenre.Text = '���') and (CBLevel.ItemIndex = 1) then
        begin
          GameStepID := 31;
          GameStepIDPlay := 31;
        end;
      if (GameStepIDBoolean <> true) and (DBLCBGenre.Text = '���-���') and (CBLevel.ItemIndex = 1) then
        begin
          GameStepID := 41;
          GameStepIDPlay := 41;
        end;
      if (GameStepIDBoolean <> true) and (DBLCBGenre.Text = '����������� ������') and (CBLevel.ItemIndex = 1) then
        begin
          GameStepID := 51;
          GameStepIDPlay := 51;
        end;
      FormGame.ClientDataSet1.Active := false;
       FormGame.SQLQuery1.Close;
        FormGame.SQLQuery1.SQL.Clear;
         FormGame.SQLQuery1.SQL.Add('SELECT * FROM Music WHERE ID = ' + IntToStr(GameStepID));
          FormGame.SQLQuery1.Open;
           FormGame.ClientDataSet1.Active := true;
      MPWithMP := Tmemorystream.Create;
      TBLOBField(FormGame.SQLQuery1.FieldByName('Music_Song')).SaveToStream(MPWithMP);
      MPWithMP.Position := 0;
      MPWithMP.SaveToFile('music\' + IntToStr(GameStepIDName) +'.mp3');
      if Timer1.Enabled = false then
        ProgressBar1.Position := 10;
      Timer1.Enabled := true;
      FreeAndNil(MPWithMP);

      GameStepIDBoolean := true;
    end
  else
    ShowMessage('�������� ����.');
end;

procedure TFormBegin.N2Click(Sender: TObject);
Var i : integer;
begin
  FormGame.MediaPlayer1.Stop;
  FormGame.MediaPlayer1.Position:=0;
  for i := 1 to 10 do
    if FileExists('music\' + IntToStr(i) +'.mp3') then
      DeleteFile('music\' + IntToStr(i) +'.mp3');
  FormBegin.Hide;
  LogOut.Show;
  Admin := 0;
end;

procedure TFormBegin.N4Click(Sender: TObject);
  Var i : integer;
begin
  for i := 1 to 10 do
    if FileExists('music\' + IntToStr(i) +'.mp3') then
      DeleteFile('music\' + IntToStr(i) +'.mp3');
  LogOut.Close;
  FormBegin.Close;
end;

procedure TFormBegin.Timer1Timer(Sender: TObject);
begin
  if FileExists('music\' + IntToStr(GameStepIDName) +'.mp3') then
    begin
      ProgressBar1.Position := ProgressBar1.Position + 10;
      GameStepIDName := GameStepIDName + 1;
      GameStepID := GameStepID + 1;
      ImageGoClick(Self);
    end;
  if ProgressBar1.Position >= 100 then
    begin
      GameStepIDName := 1;
      Timer1.Enabled := false;
      FormBegin.Hide;
      FormGame.Show;
    end;
end;

end.
