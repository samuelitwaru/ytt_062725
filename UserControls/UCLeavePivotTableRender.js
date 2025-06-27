function UCLeavePivotTable($) {
	 this.setLeaveTypeCollection = function(value) {
			this.LeaveTypeCollection = value;
		}

		this.getLeaveTypeCollection = function() {
			return this.LeaveTypeCollection;
		} 
	  
	 this.setSDTEmployeeLeaveDetailsCollection = function(value) {
			this.SDTEmployeeLeaveDetailsCollection = value;
		}

		this.getSDTEmployeeLeaveDetailsCollection = function() {
			return this.SDTEmployeeLeaveDetailsCollection;
		} 
	  
	 this.setLeaveRequest = function(value) {
			this.LeaveRequest = value;
		}

		this.getLeaveRequest = function() {
			return this.LeaveRequest;
		} 
	  
	  
	  

	var template = '<div id=\"print\" style=\"padding-top:1px;overflow:scroll; scrollbar-width:none; border-right: 1px solid #dddddd; border-left: 1px solid #dddddd\">	<table class=\"my-sticky-column-table gx-tab-spacing-fix-2 GridWithPaginationBar GridWithBorderColor WorkWith table-responsive\" style=\'border: 1px solid #dddddd; border-collapse: collapse;\'>		<thead  style=\"border-collapse: collapse; position:sticky; top:0; z-index:10\">			<tr>				<th class=\'text-center\' style=\"border: 1px solid #dddddd; border-collapse: collapse; position:sticky;left:0; background:white;\">Employees:</th>				<th style=\"border: 1px solid #dddddd; border-collapse: collapse;padding: 5px; background:#f5f5f5;\" scope=\"col\" class=\"text-center\">Date</th>				{{#LeaveTypeCollection}}				<th style=\"border: 1px solid #dddddd; border-collapse: collapse;padding: 5px; background:#f5f5f5;\" scope=\"col\" class=\"text-center\"><a id=\'LeaveType-{{LeaveTypeId}}\' style=\'cursor:pointer\' class=\'leave-type\' >{{LeaveTypeName}}</a></th>				{{/LeaveTypeCollection}}				<th style=\"border: 1px solid #dddddd; border-collapse: collapse; padding:5px; background:#f5f5f5;\" class=\"work text-center\">Leave Balance</th>			</tr>		</thead>						<tbody style=\'max-height:100px\'>			{{#SDTEmployeeLeaveDetailsCollection}}			<tr class=\"GridWithPaginationBar GridNoBorder WorkWithOdd text-center\">					<td rowspan=\'{{LeaveRequestCount}}\' style=\"border: 1px solid #dddddd; border-collapse: collapse;font-weight: bold;background:#f5f5f5; position:sticky; left:0; z-index:1\" class=\'text-center\'><a style=\'cursor:pointer\' id=\"Employee-{{EmployeeId}}\" class=\"employee\" >{{EmployeeName}}</a></td>				<td style=\'border: 1px solid #dddddd; border-collapse: collapse;\' class=\"text-center\">{{FirstLeaveRequestStartDateString}}</td>								{{#LeaveTypeCollection}}				<td id=\'{{EmployeeId}}-{{LeaveTypeId}}-{{FirstLeaveRequestId}}\' style=\'border: 1px solid #dddddd; border-collapse: collapse;\' class=\"leave-duration text-center\">  </td>				{{/LeaveTypeCollection}}								<td rowspan=\'{{LeaveRequestCount}}\' class=\"work text-center\" style=\'border: 1px solid #dddddd; border-collapse: collapse;font-weight: bold;background:#f5f5f5;\'>					{{EmployeeBalance}}				</td>			</tr>			{{#LeaveRequest}}			<tr class=\"GridWithPaginationBar GridNoBorder WorkWithOdd text-center\">								<td style=\"border: 1px solid #dddddd; border-collapse: collapse;padding: 4px\" class=\"text-center\">{{LeaveRequestStartDateString}}</td>								{{#LeaveTypeCollection}}				<td id=\'{{EmployeeId}}-{{LeaveTypeId}}-{{LeaveRequestId}}\' style=\'border: 1px solid #dddddd; border-collapse: collapse;\' class=\"leave-duration text-center\">  </td>				{{/LeaveTypeCollection}}								<td class=\"work text-center\" style=\'border: 1px solid #dddddd; border-collapse: collapse;font-weight: bold;background:#f5f5f5;\'>									</td>			</tr>			{{/LeaveRequest}}									{{/SDTEmployeeLeaveDetailsCollection}}		</tbody>		</table></div><script type=\"text/javascript\">    $(document).ready(function() {			$(window).on(\'resize\', function() {			// Your code here			var newHeight = $(window).height();			console.log(\"New height: \" + newHeight);			$(\'#print\').css(\"height\", newHeight-100)			// Perform actions based on the new height		}); 	}); </script>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnOnLeaveTypeClicked = 0; 
	var _iOnOnEmployeeClicked = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnOnLeaveTypeClicked = 0; 
			_iOnOnEmployeeClicked = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='OnLeaveTypeClicked']")
				.on('leavetypeclicked', this.onOnLeaveTypeClickedHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 
			$(this.getContainerControl())
				.find("[data-event='OnEmployeeClicked']")
				.on('employeeclicked', this.onOnEmployeeClickedHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.Start(); 
	}

	this.Scripts = [];

		this.Start = function() {

					const UC = this
					console.log(this.SDTEmployeeLeaveDetailsCollection)
					for (let i = 0; i < this.SDTEmployeeLeaveDetailsCollection.length; i++) {
						const item = this.SDTEmployeeLeaveDetailsCollection[i];
						let element = document.getElementById(item.EmployeeId +'-'+ item.FirstLeaveTypeId+'-'+item.FirstLeaveRequestId)
						
						if (element) {
							element.innerHTML = item.FirstLeaveRequestDuration
						}
						if(item.LeaveRequest){
							for (let j = 0; j < item.LeaveRequest.length; j++) {
								const leaveRequestItem = item.LeaveRequest[j];
								element = document.getElementById(item.EmployeeId +'-'+ leaveRequestItem.LeaveTypeId+'-'+leaveRequestItem.LeaveRequestId)
								
								if (element) {
									element.innerHTML = leaveRequestItem.LeaveRequestDuration
								}
								
							}
						}
					}
					
					var leaveTypeElements = document.getElementsByClassName("leave-type");
					var employeeElements = document.getElementsByClassName("employee");
					
					
					for (var i = 0; i < leaveTypeElements.length; i++) {
						var leaveTypeElement = leaveTypeElements[i]
						leaveTypeElement.addEventListener("click", function(e){
							console.log(e.target)
							UC.LeaveTypeId = parseInt(e.target.id.split('-')[1])
							UC.OnLeaveTypeClicked()
						})
					}
				
					for (var i = 0; i < employeeElements.length; i++) {
						var employeeElement = employeeElements[i]
						employeeElement.addEventListener("click", function(e){
							UC.EmployeeId = parseInt(e.target.id.split('-')[1])
							UC.OnEmployeeClicked()
						})
					}
				
				
				
					$(document).ready(function() {
						$(window).on('resize', function() {
							// Your code here
							var newHeight = $(window).height();
							console.log(newHeight-100);
							$('#print').css("height", newHeight-100)
							// Perform actions based on the new height
						});
					});
				
					

				
		}


		this.onOnLeaveTypeClickedHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 this.LeaveTypeCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 this.SDTEmployeeLeaveDetailsCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 this.LeaveRequestCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 
				 
			}

			if (this.OnLeaveTypeClicked) {
				this.OnLeaveTypeClicked();
			}
		} 

		this.onOnEmployeeClickedHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 this.LeaveTypeCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 this.SDTEmployeeLeaveDetailsCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 this.LeaveRequestCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 
				 
			}

			if (this.OnEmployeeClicked) {
				this.OnEmployeeClicked();
			}
		} 

	this.autoToggleVisibility = true;

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}