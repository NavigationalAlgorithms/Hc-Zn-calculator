
function CheckFrame(top_frame,l,n)

{ 
  if(self.name=="mainwin") parent.GenerateBanner(l,n)
 //   else self.location=top_frame;

  return;
}

function CheckTopFrame(top_frame,l,n,force)

{ 
  if(self.name=="mainwin") parent.GenerateBanner(l,n)
    else if(force==1) self.location=top_frame;

  return;
}
