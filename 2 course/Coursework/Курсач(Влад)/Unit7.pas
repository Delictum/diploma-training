unit Unit7;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ComCtrls, DBXMySQL, Vcl.StdCtrls,
  Vcl.DBCtrls, Vcl.Imaging.jpeg, Vcl.ExtCtrls, Data.DB, Data.SqlExpr,
  Data.FMTBcd, Datasnap.DBClient, Datasnap.Provider;

type
  TFormGame2 = class(TForm)
    PageControl1: TPageControl;
    TabSheet1: TTabSheet;
    Image1: TImage;
    DBRichEdit1: TDBRichEdit;
    DBRichEdit2: TDBRichEdit;
    RichEdit1: TRichEdit;
    RichEdit2: TRichEdit;
    RichEdit3: TRichEdit;
    TabSheet2: TTabSheet;
    Image2: TImage;
    DBRichEdit3: TDBRichEdit;
    DBRichEdit4: TDBRichEdit;
    RichEdit4: TRichEdit;
    RichEdit5: TRichEdit;
    RichEdit6: TRichEdit;
    TabSheet3: TTabSheet;
    Image3: TImage;
    DBRichEdit5: TDBRichEdit;
    DBRichEdit6: TDBRichEdit;
    RichEdit7: TRichEdit;
    RichEdit8: TRichEdit;
    RichEdit9: TRichEdit;
    TabSheet4: TTabSheet;
    Image4: TImage;
    DBRichEdit7: TDBRichEdit;
    DBRichEdit8: TDBRichEdit;
    RichEdit10: TRichEdit;
    RichEdit11: TRichEdit;
    RichEdit12: TRichEdit;
    TabSheet5: TTabSheet;
    Image5: TImage;
    DBRichEdit9: TDBRichEdit;
    DBRichEdit10: TDBRichEdit;
    RichEdit13: TRichEdit;
    RichEdit14: TRichEdit;
    RichEdit15: TRichEdit;
    TabSheet6: TTabSheet;
    Image6: TImage;
    DBRichEdit11: TDBRichEdit;
    DBRichEdit12: TDBRichEdit;
    RichEdit16: TRichEdit;
    RichEdit17: TRichEdit;
    RichEdit18: TRichEdit;
    TabSheet7: TTabSheet;
    Image7: TImage;
    DBRichEdit13: TDBRichEdit;
    DBRichEdit14: TDBRichEdit;
    RichEdit19: TRichEdit;
    RichEdit20: TRichEdit;
    RichEdit21: TRichEdit;
    TabSheet8: TTabSheet;
    Image8: TImage;
    DBRichEdit15: TDBRichEdit;
    DBRichEdit16: TDBRichEdit;
    RichEdit22: TRichEdit;
    RichEdit23: TRichEdit;
    RichEdit24: TRichEdit;
    TabSheet9: TTabSheet;
    Image9: TImage;
    DBRichEdit17: TDBRichEdit;
    DBRichEdit18: TDBRichEdit;
    RichEdit25: TRichEdit;
    RichEdit26: TRichEdit;
    RichEdit27: TRichEdit;
    TabSheet10: TTabSheet;
    Image10: TImage;
    DBRichEdit19: TDBRichEdit;
    DBRichEdit20: TDBRichEdit;
    RichEdit28: TRichEdit;
    RichEdit29: TRichEdit;
    RichEdit30: TRichEdit;
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure FormShow(Sender: TObject);
    procedure RichEdit2Click(Sender: TObject);
    procedure DBRichEdit2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FormGame2: TFormGame2;

implementation

{$R *.dfm}

uses Unit5, Unit6, Unit3, Unit9;

procedure TFormGame2.DBRichEdit2Click(Sender: TObject);
begin
  inc(GameStepID);

  FormGame1.ClientDataSet1.Active := false;
  FormGame1.SQLQuery1.Close;
  FormGame1.SQLQuery1.SQL.Clear;
  FormGame1.SQLQuery1.SQL.Add('SELECT *  FROM Answers WHERE AnswersQuestionsID = ' + IntToStr(GameStepID));
  FormGame1.SQLQuery1.Open;
  FormGame1.ClientDataSet1.Active := true;

  FormGame1.ClientDataSet2.Active := false;
  FormGame1.SQLQuery2.Close;
  FormGame1.SQLQuery2.SQL.Clear;
  FormGame1.SQLQuery2.SQL.Add('SELECT *  FROM Questions WHERE QuestionsID = ' + IntToStr(GameStepID));
  FormGame1.SQLQuery2.Open;
  FormGame1.ClientDataSet2.Active := true;

  Otvet := Otvet + sqr(Otvet) + 1;
  if PageControl1.ActivePageIndex = 9 then
    begin
      FormGame2.Hide;
      FormEnd.Show;
      exit;
    end;

  PageControl1.ActivePageIndex := PageControl1.ActivePageIndex + 1;
end;

procedure TFormGame2.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  FormBegin.Close;
  LogOut.Close;
end;

procedure TFormGame2.FormShow(Sender: TObject);
begin
  FormGame1.ClientDataSet1.Active := false;
  FormGame1.SQLQuery1.Close;
  FormGame1.SQLQuery1.SQL.Clear;
  FormGame1.SQLQuery1.SQL.Add('SELECT *  FROM Answers WHERE AnswersQuestionsID = ' + IntToStr(GameStepID));
  FormGame1.SQLQuery1.Open;
  FormGame1.ClientDataSet1.Active := true;

  FormGame1.ClientDataSet2.Active := false;
  FormGame1.SQLQuery2.Close;
  FormGame1.SQLQuery2.SQL.Clear;
  FormGame1.SQLQuery2.SQL.Add('SELECT *  FROM Questions WHERE QuestionsID = ' + IntToStr(GameStepID));
  FormGame1.SQLQuery2.Open;
  FormGame1.ClientDataSet2.Active := true;
end;

procedure TFormGame2.RichEdit2Click(Sender: TObject);
begin
  FormGame2.Hide;
  FormEnd.Show;
end;

end.
