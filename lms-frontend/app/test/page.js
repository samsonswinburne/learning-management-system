import SideBar2 from "../components/sidebar2";

export default function Page(){
    return(
        <div className="">
            <SideBar2/>
            <div className="ml-50 mr-50 h-screen flex-grow flex">

            
            <div className="  mt-10 mb-10 grid grid-cols-2 grid-rows-2 flex-grow text-center">
            <div className="bg-amber-100 box_text">hello</div>
             <div className="bg-gray-600 box_text">hello</div>
              <div className="bg-red-400 box_text">hello</div>
               <div className="bg-blue-600 box_text">
                <i>item</i><i>item</i>
                </div>
            </div>
            </div>
        </div>
        

        
    );
}