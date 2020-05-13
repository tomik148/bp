var tempList = new object[ItemsPerBatch][];
using (var data = cmd.ExecuteReader()){
  while (data.Read()){
    object[] obj = new object[data.FieldCount];
    data.GetValues(obj);
    tempList[count++] = obj;
    if (count >= ItemsPerBatch){
      LZ4MessagePackSerializer.Serialize(Response.Body, tempList);
      count = 0;
    }
  }
  LZ4MessagePackSerializer.Serialize(Response.Body, tempList.Take(count));
  LZ4MessagePackSerializer.Serialize(Response.Body, null);
}