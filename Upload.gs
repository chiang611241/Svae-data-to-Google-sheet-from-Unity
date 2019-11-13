function doPost(e){
  var app = SpreadsheetApp.openById("1-LWytQOZcBFECRyrvwnmZZRvgbVF7UT_CygtWJ6IcA0"); //試算表
  var sheet = app.getSheets()[0]; //工作表 USER
  var parameter = e.parameter; //取得值
 
  var lastRow; //最後的行(直)
  var lastColumn;  //最後的列(橫)
  var row;
  var column;

  if(parameter.method == "read"){
    
    lastRow = sheet.getLastRow();
    var i;
    for(i=1;i<=lastRow;i++){
      var user_name = sheet.getSheetValues(i,1,1,1); //從A1開始取值 一次一個
      if(user_name == parameter.name){
        var user_pw = sheet.getSheetValues(i,2,1,1); //從Bi開始
        if(user_pw == parameter.password){
          return ContentService.createTextOutput(sheet.getRange(i,1).getValue());
        }
        else{
          return ContentService.createTextOutput("0");
        }
      }
      if(i==lastRow && user_name != parameter.name){
        return ContentService.createTextOutput("0");
      }
    }
  }
  //寫入ok
  if(parameter.method == "write"){
    var data = [parameter.name,parameter.password];
    sheet.appendRow(data);
    lastRow = sheet.getLastRow();
    lastColumn = sheet.getLastColumn();
    return ContentService.createTextOutput(sheet.getRange(lastRow,1).getValue());
  }
  
}